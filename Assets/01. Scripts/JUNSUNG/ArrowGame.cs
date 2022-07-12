using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace JUNSUNG
{
    public class ArrowGame : MonoBehaviour
    {
        [SerializeField] private float time = 30;
        [SerializeField] private TextMeshProUGUI timeText = null;
        [SerializeField] private TextMeshProUGUI scoreText = null;
        [SerializeField] private TextMeshProUGUI startText = null;
        [SerializeField] private GameObject currentArrow = null;
        [SerializeField] private Transform boxTrm = null;
        private RectTransform startTextTrm = null;
        Vector3 startTextInitPos;
        Color startTextInitColor;

        [SerializeField] private List<GameObject> _arrowList = new List<GameObject>();
        private List<GameObject> arrowList = new List<GameObject>();

        private GameObject endPanel = null;

        [SerializeField] private float fadeTime = 1f;

        private int score = 0;
        private int GetMoney = 0;
        private bool isEnd = false;
        private bool isStart = false;

        private void Awake()
        {
            startTextTrm = GameObject.Find("Canvas/TextPanel/StartText").GetComponent<RectTransform>();
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

            scoreText.text = "0¡°";

            startTextInitPos = startTextTrm.transform.position;
            startTextInitColor = startText.color;
        }

        private void Start()
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(0, 158, 0)));
            Debug.Log(startTextTrm.transform.position);
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

            if (Input.GetKeyDown(KeyCode.UpArrow) && currentArrow.name == "UpArrow")
            {
                ShortLogic();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && currentArrow.name == "DownArrow")
            {
                ShortLogic();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && currentArrow.name == "RightArrow")
            {
                ShortLogic();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && currentArrow.name == "LeftArrow")
            {
                ShortLogic();
            }
        }

        IEnumerator StartText()
        {
            int i = 3;

            while (i >= 0)
            {
                yield return new WaitForSeconds(0.5f);
                startText.text = $"{i}";
                Sequence sq = DOTween.Sequence();
            }
        }

        private void ShortLogic()
        {
            currentArrow.SetActive(false);
            currentArrow.transform.parent = this.transform;
            arrowList.Add(currentArrow);
            scoreText.text = $"{++score}¡°";
            GameObject arrow = arrowList[0];
            arrowList.Remove(arrow);
            arrow.SetActive(true);
            arrow.transform.parent = boxTrm;
        }

        private void End()
        {
            if (time <= 0)
            {
                isEnd = true;
                endPanel.SetActive(true);
                GetMoney = score * 1000000;

                endPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"{GetMoney}ø¯ »πµÊ";
            }
        }

        IEnumerator FadeEffect(float start, float end)
        {
            float currentTime = 0;
            float percent = 0;
            Color color = startText.color;

            for (int i = 3; i >= 0; i--)
            {
                yield return new WaitForSeconds(1);
                startText.SetText(i.ToString());
                if(i == 0) { startText.SetText("Ω√¿€!"); }
                startTextTrm.DOMoveY(145f, 1);
                currentTime = 0;
                percent = 0;

                while (percent < 1)
                {
                    currentTime += Time.deltaTime;
                    Debug.Log(currentTime);
                    percent = currentTime / fadeTime;
            
                    color.a = Mathf.Lerp(start, end, percent);
                    startText.color = color;

                    yield return null;
                }
               
                startTextTrm.transform.position = startTextInitPos;
                startText.color = startTextInitColor;
            }

            isStart = true;
        }
    }
}
