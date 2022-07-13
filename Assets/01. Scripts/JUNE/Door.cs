using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JUNE
{
    public class Door : MonoBehaviour
    {
        [SerializeField] GameObject febreeze;
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
            currentTime = 0;
            percent = 0;
            c.a = 1;
            image.color = c;
        }

        private void Update()
        {
            if (percent > 1)
            {
                gameObject.SetActive(false);
            }
        }
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject == febreeze)
            {
                currentTime += Time.deltaTime;
                percent = currentTime / 1;

                c.a = 1 - percent;
                image.color = c;
            }
        }
    }
}
