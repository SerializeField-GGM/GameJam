using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;
using TMPro;
using DG.Tweening;

namespace JUNSUNG
{
    public class ArrowGame : MonoBehaviour
    {
        [SerializeField] private float time = 30;
        [SerializeField] private TextMeshProUGUI timeText = null;
        [SerializeField] private TextMeshProUGUI scoreText = null;
        [SerializeField] private GameObject currentArrow = null;
        [SerializeField] private Transform boxTrm = null;
        [SerializeField] private Image cntImage = null; 
        
        private RectTransform cntImageTrm = null;   
        Vector3 cntImageInitPos;
        Color cntImageInitColor;

        [SerializeField] private Sprite[] cnt = new Sprite[4];
        [SerializeField] private List<GameObject> _arrowList = new List<GameObject>();
        private List<GameObject> arrowList = new List<GameObject>();

        private GameObject endPanel = null;

        [SerializeField] private float fadeTime = 1f;

        private int score = 0;
        private int GetMoney = 0;
        private bool isEnd = false;
        private bool isStart = false;

        [SerializeField] AudioClip successSound;
        [SerializeField] AudioClip failSound;
        private void Awake()
        {
            cntImageTrm = cntImage.GetComponent<RectTransform>();
            endPanel = GameObject.Find("EndPanel").gameObject;
            endPanel.SetActive(false);

            for (int i = 0; i < 80; i++)
            {
                GameObject arrow = null;
                int randVal = UnityEngine.Random.Range(0, 4);

                arrow = Instantiate(_arrowList[randVal], transform);
                arrow.gameObject.name = arrow.gameObject.name.Replace("(Clone)", null);
                arrow.SetActive(false);
                arrowList.Add(arrow);
            }

            for (int i = 0; i < 4; i++)
            {
                GameObject arrow = arrowList[0];
                arrowList.Remove(arrow);
                arrow.SetActive(true);
                arrow.transform.parent = boxTrm;
            }

            scoreText.text = "0점";

            cntImageInitPos = cntImageTrm.transform.position;
            cntImageInitColor = cntImage.color;
        }

        private void Start()
        {
            StartCoroutine(FadeEffect(0, 1));
        }

        void Update()
        {
            End();

            if (isEnd || !isStart) { return; }

            TimeSet();
            Play();
        }

        private void TimeSet()
        {
            time -= Time.deltaTime;
            time = Mathf.Max(time, 0);
            timeText.text = time.ToString("F2");

            if (time <= 5) { timeText.color = Color.red; }
        }

        private void Play()
        {
            currentArrow = boxTrm.GetChild(0).gameObject;


            for (int i = 0; i < boxTrm.childCount; i++)
            {
                boxTrm.GetChild(i).transform.position = new Vector2(boxTrm.position.x + i * 4, boxTrm.position.y);
            }

            if(Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                if(currentArrow.gameObject.name == "RightArrow") 
                {
                    ShortLogic();
                    SuccessSoundPlay();
                }
                else 
                {
                    time -= 0.2f;
                    FailSound();
                }
            }
            if(Input.GetKeyDown(KeyCode.UpArrow)) 
            {
                if(currentArrow.gameObject.name == "UpArrow")
                { 
                    ShortLogic();
                    SuccessSoundPlay();
                }
                else 
                {
                    time -= 0.2f;
                    FailSound();
                }
            }
            if(Input.GetKeyDown(KeyCode.DownArrow)) 
            {
                if(currentArrow.gameObject.name == "DownArrow") 
                {
                    ShortLogic();
                    SuccessSoundPlay();
                }
                else 
                {
                    time -= 0.2f;
                    FailSound();
                }
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow)) 
            {
                if(currentArrow.gameObject.name == "LeftArrow") 
                {
                    ShortLogic();
                    SuccessSoundPlay();
                }
                else 
                {
                    time -= 0.2f;
                    FailSound();
                }
            }
        }

        private void ShortLogic()
        {
            currentArrow.SetActive(false);
            currentArrow.transform.parent = this.transform;
            arrowList.Add(currentArrow);
            scoreText.text = $"{++score}점";
            GameObject arrow = arrowList[0];
            arrowList.Remove(arrow);
            arrow.SetActive(true);
            arrow.transform.parent = boxTrm;
        }

        private void End()
        {
            if (time <= 0 && !isEnd)
            {
                isEnd = true;
                endPanel.SetActive(true);
                GetMoney = score * 2500;
                MoneyManager.Instance.SetMoney(GetMoney);
                endPanel.transform.Find("MoneyText").GetComponent<TextMeshProUGUI>().text = $"{GetMoney}원 획득";
            }
        }

        IEnumerator FadeEffect(float start, float end)
        {
            float currentTime = 0;
            float percent = 0;
            Color color = cntImage.color;

            for (int i = 0; i < 4; i++)
            {
                yield return new WaitForSeconds(1);
                cntImage.sprite = cnt[i];
                cntImageTrm.DOMove(Camera.main.WorldToScreenPoint(new Vector3(0, 1.3f, 0)), 1);
                currentTime = 0;
                percent = 0;

                while (percent < 1)
                {
                    currentTime += Time.deltaTime;
                    percent = currentTime / fadeTime;
            
                    color.a = Mathf.Lerp(start, end, percent);
                    cntImage.color = color;

                    yield return null;
                }

                cntImageTrm.transform.position = cntImageInitPos;
                cntImage.color = cntImageInitColor;
            }

            isStart = true;
        }

        public void SuccessSoundPlay()
        {
            SoundControll.Instance.PlayButtonSound(successSound);
        }
        public void FailSound()
        {
            SoundControll.Instance.PlayButtonSound(failSound);
        }
    }
}
