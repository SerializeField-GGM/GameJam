using Core;
using UnityEngine;

namespace SEH00N
{
    public class FinalExam : MainEvent
    {
        [SerializeField] float stressMin, stressMax, talentMin, talentMax;

        private void Start()
        {
            temp = PlayerPrefs.GetInt("FinalExam", 0);

            if(temp == 1)
                button.interactable = false;
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt("FinalExam", temp);
        }

        public void DoEvent()
        {
            OnClick();
            float stressAmount = Random.Range(stressMin, stressMax);
            float talentAmount = Random.Range(talentMin, talentMax);
            StudentState.Instance.AddStress(stressAmount);
            StudentState.Instance.AddTalent(talentAmount);
            eventText.text = $"{positiveWriting}\n스트레스 +{stressAmount.ToString("0.0")}\n 능력 +{talentAmount.ToString("0.0")}";
        }
    }
}

