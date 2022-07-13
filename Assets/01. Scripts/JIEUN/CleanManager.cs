using UnityEngine;
using UnityEngine.UI;
using Core;
using System.Collections;
using TMPro;

namespace JIEUN
{
    public class CleanManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI gameovertxt;
        [SerializeField] GameObject gameoverPanel;
        [SerializeField] PoolableMono dust = null;
        [SerializeField] Transform min, max;
        [SerializeField] GameObject scorePanel = null;
        [SerializeField] Slider timer = null;
        [SerializeField] float currentTime = 0;
        [SerializeField] float maxTime = 25;
        public int i ;//{ get; set; }s
        private bool isOver = false;
        private Transform canvas;
        private Camera cam = null;

        public static CleanManager Instance;

        private void Awake() {
            if(Instance == null)
                Instance = this;

            canvas = GameObject.Find("Canvas").transform;
            cam = Camera.main;

            gameoverPanel.SetActive(false);
        }

        private void Update() 
        {
            if(currentTime < maxTime)
                currentTime += Time.deltaTime;
    
            
            timer.value = currentTime / maxTime;

            if(timer.value >= 1 && !isOver)
            {
                gameoverPanel.SetActive(true);
                isOver = true;
                int randStress = Random.Range(-5, 6);
                int getMoney = ScoreManager.Instance.dustCount * 2100;
                if(randStress > 0)
                    gameovertxt.text = $"청소를 열심히 해서 상점을 받았다!\n스트레스 +{randStress}\n{getMoney}원";
                else
                    gameovertxt.text = $"앗! 먼지가 남아있었네..\n스트레스 {randStress}\n{getMoney}원";
                MoneyManager.Instance.SetMoney(ScoreManager.Instance.dustCount * 120393);
                StudentState.Instance.AddStress(Random.Range(-5, 6));
                Time.timeScale = 0;
            }
        }

        private void Start() {
            StartCoroutine(Spawn());
        }
        IEnumerator Spawn()
        {
            while(true)
            {
                if(i < 7)
                {
                    PoolableMono temp = PoolManager.Instance.Pop(dust);
                    temp.transform.SetParent(canvas);
                    temp.transform.position = cam.WorldToScreenPoint(new Vector3(Random.Range(min.position.x, max.position.x),
                    Random.Range(min.position.y, max.position.y)));
                    i++;
                    yield return new WaitForSeconds(1f);
                }
                yield return null;
            }
        }
    }
}
