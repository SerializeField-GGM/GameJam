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
        private TimeManager timeManager = null;

        private void Awake()
        {
            fillImage = transform.Find("Image").transform.Find("FillImage").GetComponent<Image>();
            timeManager = GameObject.Find("Main/TimeManager").GetComponent <TimeManager>();
        }

        private void Update()
        {
            fillImage.fillAmount = timeManager.currentTime / timeManager.delay;
        }
    }
}
