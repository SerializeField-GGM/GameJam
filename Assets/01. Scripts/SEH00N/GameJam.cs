using UnityEngine;
using Core;

namespace SEH00N
{
    public class GameJam : MainEvent
    {
        [SerializeField] float passionMin, passionMax, stressMin, stressMax;

        public void DoEvent()
        {
            OnClick();
            int randVal = Random.Range(0, 4);
            if(randVal == 0)
            {
                float passionAmount = Random.Range(20, passionMax);
                float stressAmount = Random.Range(stressMin, stressMax);
                StudentState.Instance.AddPassion(passionAmount);
                StudentState.Instance.AddStress(stressAmount);
                eventText.text = $"{positiveWriting}\n열정 +{passionAmount.ToString("0.0")}\n스트레스 +{stressAmount.ToString("0.0")}";
            }
            else
            {
                float passionAmount = Random.Range(passionMin, -1);
                float stressAmount = Random.Range(stressMin, stressMax);
                StudentState.Instance.AddPassion(passionAmount);
                StudentState.Instance.AddStress(stressAmount);
                eventText.text = $"{negativeWriting}\n열정 {passionAmount.ToString("0.0")}\n스트레스 +{stressAmount.ToString("0.0")}";
            }
        }
    }
}
