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

        public void TextSeason()//TimeManager DoPopUP�̺�Ʈ�� �־��
        {
            if (timeManager.season == TimeManager.Season.Spring) { seasonString = "�ܿ���  ����  ����  �Խ��ϴ�."; }
            if (timeManager.season == TimeManager.Season.Summer) { seasonString = "����  ����  ������  �Խ��ϴ�."; }
            if (timeManager.season == TimeManager.Season.Fall) { seasonString = "������  ����  ������  �Խ��ϴ�."; }
            if (timeManager.season == TimeManager.Season.Winter) { seasonString = "������  ����  �ܿ���  �Խ��ϴ�."; }

            seasonText.SetText(seasonString);
        }
    }
}
