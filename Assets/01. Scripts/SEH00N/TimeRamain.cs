using UnityEngine.UI;
using UnityEngine;

namespace SEH00N
{
    public class TimeRamain : MonoBehaviour
    {
        [SerializeField] float limitTime;
        private Slider slider = null;
        private float currentTime = 0;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        private void Update()
        {
            currentTime += Time.deltaTime;
            slider.value = (limitTime - currentTime) / limitTime;
            if(slider.value <= 0) Debug.Log($"게임오버!");
        }
    }
}
