using System.Collections;
using System.Collections.Generic;
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
            slider.value = totaltime / 15;

            if(slider.value == 1)
            {
                eatUpPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }

        IEnumerator SpawnTeacher()
        {
            while(slider.value < 1)
            {
                int random = Random.Range(1,101);
                if(random <= 8)
                {
                    text.SetActive(true);
                    break;
                }
                yield return new WaitForSeconds(1.5f);
            }
        }
    }
}
