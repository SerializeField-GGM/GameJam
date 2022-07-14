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
        //[SerializeField] GameObject scorePanel = null;
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
                int getMoney = ScoreManager.Instance.dustCount * 4100;
                if(randStress > 0)
                    gameovertxt.text = $"에잇시팔\n스트레스 +{randStress}\n{getMoney}원";
                else
                    gameovertxt.text = $"오예\n스트레스 {randStress}\n{getMoney}원";
                MoneyManager.Instance.SetMoney(getMoney);
                StudentState.Instance.AddStress(randStress);
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
                    yield return new WaitForSeconds(0.6f);
                }
                yield return null;
            }
        }
    }
}
