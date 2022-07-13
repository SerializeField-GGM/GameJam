using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JUNE
{
    public class RamenTime : MonoBehaviour
    {
        Image image;
        private float time = 0;
        private void Awake()
        {
            image = GetComponent<Image>();
        }
        private void OnEnable()
        {
            time = 0;
            image.fillAmount = 0;
        }
        void Update()
        {
            time += Time.deltaTime;
            image.fillAmount = time / 10;
        }
    }
}
