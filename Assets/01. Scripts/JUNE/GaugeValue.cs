using Core;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace JUNE
{
    public class GaugeValue : MonoBehaviour
    {
        Slider slider;
        float totaltime = 0;

        [SerializeField] GameObject text;
        [SerializeField] GameObject eatUpPanel;
        private bool isOver = false;

        void Awake()
        {
            slider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            totaltime = 0;
            slider.value = 0;
            StartCoroutine(SpawnTeacher());  
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        void Update()
        {
            totaltime += Time.deltaTime;
            slider.value = totaltime / 10;

            if(slider.value == 1 && !isOver)
            {
                isOver = true;
                eatUpPanel.SetActive(true);
                DataManager.Instance.std.stress -= 3;
                StudentState.Instance.AddStress(-3);
                Time.timeScale = 0;
            }
        }

        IEnumerator SpawnTeacher()
        {
            while(slider.value < 1)
            {
                int random = Random.Range(1,101);
                if(random <= 13)
                {
                    text.SetActive(true);
                    break;
                }
                yield return new WaitForSeconds(1.5f);
            }
        }
    }
}
