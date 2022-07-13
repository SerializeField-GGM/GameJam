using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JUNSUNG;

namespace JUNE
{
    public class Soup : MonoBehaviour
    {
        [SerializeField] GameObject TrashCan;
        [SerializeField] AudioClip wasteAudio;
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
                SoundControll.Instance.PlayButtonSound(wasteAudio);
                gameObject.SetActive(false);
            }
        }
    }
}
