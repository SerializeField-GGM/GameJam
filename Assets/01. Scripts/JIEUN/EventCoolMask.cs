using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace JIEUN
{
    public class EventCoolMask : MonoBehaviour
    {

        [SerializeField] float coolTime = 0;
        [SerializeField] float currentTime = 0;
        private Button button  = null;
        private Image image = null;

        private void Awake()
        {
            image = GetComponent<Image>();
            image.fillAmount = (coolTime - currentTime) / coolTime;
            button = GetComponentInParent<Button>();
            currentTime = coolTime;
        }

        private void Update()
        {
            currentTime += Time.deltaTime;
            image.fillAmount = (coolTime - currentTime) / coolTime;
            if(image.fillAmount > 0) button.interactable = false;
            else button.interactable = true;
        }

        #region 코루틴로직

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
        #endregion
    }
}
