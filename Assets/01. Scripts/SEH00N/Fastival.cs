using UnityEngine;
using Core;

namespace SEH00N
{
    public class Fastival : MainEvent
    {
        [SerializeField] float passionMin, passionMax, stressMin, stressMax;

        private void Start()
        {
            temp = PlayerPrefs.GetInt("Fastival", 0);

            if(temp == 1)
                button.interactable = false;
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt("Fastival", temp);
        }

        public void DoEvent()
        {
            OnClick();
            float stressAmount = Random.Range(stressMin, stressMax);
            float passionAmount = Random.Range(passionMin, passionMax);
            StudentState.Instance.AddStress(stressAmount);
            StudentState.Instance.AddPassion(passionAmount);
            eventText.text = $"{positiveWriting}\n스트레스 {stressAmount.ToString("0.0")}\n 열정 +{passionAmount.ToString("0.0")}";
        }
    }
}

