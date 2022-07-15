using UnityEngine;
using Core;

namespace SEH00N
{
    public class GIGDC : MainEvent
    {
        [SerializeField] float talentMin, talentMax, fameMin, fameMax;

        private void Start()
        {
            temp = PlayerPrefs.GetInt("GIGDC", 0);
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt("GIGDC", temp);
        }

        public void DoEvent()
        {
            OnClick();
            int randVal = Random.Range(0, 4);
            if(randVal == 0)
            {
                float talentAmount = Random.Range(talentMin, talentMax);
                int fameAmount = (int)Random.Range(fameMin, fameMax);
                FameManager.Instance.SetFame(fameAmount);
                StudentState.Instance.AddTalent(talentAmount);
                eventText.text = $"{positiveWriting}\n능력 +{talentAmount.ToString("0.0")}\n명성 +{fameAmount}";
            }
            else
            {
                float talentAmount = Random.Range(talentMin, talentMax);
                StudentState.Instance.AddTalent(talentAmount);
                eventText.text = $"{negativeWriting}\n능력 +{talentAmount.ToString("0.0")}";
            }
        }
    }
}

