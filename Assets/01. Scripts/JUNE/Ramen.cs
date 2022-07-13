using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JUNSUNG;

namespace JUNE
{
    public class Ramen : MonoBehaviour
    {
        [SerializeField] GameObject Cabinet;
        [SerializeField] AudioClip ramenttang;
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
                SoundControll.Instance.PlayButtonSound(ramenttang);
                gameObject.SetActive(false);
            }
        }
    }
}
