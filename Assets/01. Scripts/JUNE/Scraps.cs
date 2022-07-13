using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JUNE
{
    public class Scraps : MonoBehaviour
    {
        [SerializeField] GameObject Broom;
        Image image;
        Color c;
        private float currentTime = 0;
        private float percent = 0;
        private void Awake()
        {
            image = GetComponent<Image>();
            c = image.color;
        }

        private void OnEnable()
        {
            percent = 0;
            currentTime = 0;
            c.a = 1;
            image.color = c;
        }

        private void Update()
        {
            if(percent > 1)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            {
                if (other.gameObject == Broom)
                {
                    currentTime += Time.deltaTime;
                    percent = currentTime / 1;

                    c.a = 1 - percent;
                    image.color = c;
                }
            }
        }
    }
}
