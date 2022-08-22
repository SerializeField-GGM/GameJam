using UnityEngine;
using UnityEngine.UI;
using Core;

namespace JUNSUNG
{
    public class Clock : MonoBehaviour
    {
        private Image fillImage = null;

        private void Awake()
        {
            fillImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        }

        private void Update()
        {
            fillImage.fillAmount = TimeManager.Instance.currentTime / TimeManager.Instance.delay;
        }
    }
}
