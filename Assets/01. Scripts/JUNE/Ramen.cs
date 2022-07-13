using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JUNE
{
    public class Ramen : MonoBehaviour
    {
        [SerializeField] GameObject Cabinet;
        RectTransform rectTransform;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        private void OnEnable()
        {
            rectTransform.localPosition = new Vector3(-42,-160);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject == Cabinet)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
