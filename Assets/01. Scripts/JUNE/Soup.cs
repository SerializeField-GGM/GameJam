using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JUNE
{
    public class Soup : MonoBehaviour
    {
        [SerializeField] GameObject TrashCan;
        RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            rectTransform.localPosition = new Vector3(177,-60);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject == TrashCan)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
