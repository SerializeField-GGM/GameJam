using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JIEUN
{
    public class EventCoolMask : MonoBehaviour
    {

        [SerializeField] float coolTime = 0;
        [SerializeField] float currentTime = 0;
        private Image image = null;

        private void Awake()
        {
            image = GetComponent<Image>();
            image.fillAmount = (coolTime - currentTime) / coolTime;
            currentTime = coolTime;
        }

        IEnumerator CoolTime()
        {
            currentTime = 0;
            image.fillAmount = (coolTime - currentTime) / coolTime;
            while (image.fillAmount > 0)
            {
                image.fillAmount = (coolTime - currentTime) / coolTime;
                currentTime += Time.deltaTime;
                yield return null;
            }
            
            yield return null;
        }

        public void EventClick()
        {
            if(image.fillAmount > 0)
                return;
            StartCoroutine(CoolTime());
        }
    }
}
