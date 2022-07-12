using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JUNE
{
    public class ValueText : MonoBehaviour
    {
        TextMeshProUGUI valueText;

        private void Awake()
        {
            valueText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            StartCoroutine(Disappear());
        }

        IEnumerator Disappear()
        {
            Debug.Log("123");
            float currentTime = 0;
            float percent = 0;
            while(percent < 1)
            {
                currentTime += Time.deltaTime;
                percent = currentTime / 1;

                Color c = valueText.color;
                c.a = 1 - percent;
                valueText.color = c;
                yield return null;
            }
            valueText.text = null;
        }
    }
}
