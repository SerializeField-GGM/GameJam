using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace JUNSUNG
{
    public class Clock : MonoBehaviour
    {
        private Image fillImage = null;

        private void Awake()
        {
            fillImage = transform.Find("Image").transform.Find("FillImage").GetComponent<Image>();
        }

        private void Update()
        {
            fillImage.fillAmount = TimeManager.Instance.currentTime / TimeManager.Instance.delay;
        }
    }
}
