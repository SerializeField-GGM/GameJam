using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using TMPro;

namespace JUNSUNG
{
    public class SeasonText : MonoBehaviour
    {
        private TimeManager timeManager = null;

        private string seasonString = null;
        private TextMeshProUGUI seasonText = null;

        private void Awake()
        {
            timeManager = GameObject.Find("Main/TimeManager").GetComponent<TimeManager>();
            seasonText = GetComponent<TextMeshProUGUI>();
        }

        public void TextSeason()//TimeManager DoPopUP�̺�Ʈ�� �־��
        {
            if (timeManager.season == TimeManager.Season.Winter)
            {
                seasonString = $"가을이 가고 봄이 왔습니다.";
                seasonString += $"\n지원금 + {timeManager.inMoneyAm}";
                seasonString += $"\n 학생수 + {timeManager.inStudentAm}";
                seasonString += $"\n명성 + {timeManager.inFameAm}";
            }
            else
            {
                if (timeManager.season == TimeManager.Season.Spring) { seasonString = $"겨울이 가고 봄이 왔습니다."; }
                if (timeManager.season == TimeManager.Season.Summer) { seasonString = $"봄이 가고 여름이 왔습니다."; }
                if (timeManager.season == TimeManager.Season.Fall) { seasonString = $"여름이 가고 가을이 왔습니다."; }
                seasonString += $"\n지원금 + {timeManager.inMoneyAm}";
            }

            seasonText.SetText(seasonString);
        }
    }
}
