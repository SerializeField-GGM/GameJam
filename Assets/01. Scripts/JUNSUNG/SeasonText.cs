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
            timeManager = GameObject.Find("GameManager/TimeManager").GetComponent<TimeManager>();
            seasonText = GetComponent<TextMeshProUGUI>();
        }

        public void TextSeason()//TimeManager DoPopUP이벤트에 넣어둠
        {
            if (timeManager.season == TimeManager.Season.Spring) { seasonString = "겨울이  가고  봄이  왔습니다."; }
            if (timeManager.season == TimeManager.Season.Summer) { seasonString = "봄이  가고  여름이  왔습니다."; }
            if (timeManager.season == TimeManager.Season.Fall) { seasonString = "여름이  가고  가을이  왔습니다."; }
            if (timeManager.season == TimeManager.Season.Winter) { seasonString = "가을이  가고  겨울이  왔습니다."; }

            seasonText.SetText(seasonString);
        }
    }
}
