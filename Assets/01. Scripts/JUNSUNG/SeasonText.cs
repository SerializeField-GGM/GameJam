using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;

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
            if (timeManager.season == TimeManager.Season.summer) { seasonString = "����  ����  ������  �Խ��ϴ�."; }
            if (timeManager.season == TimeManager.Season.Fall) { seasonString = "������  ����  ������  �Խ��ϴ�."; }
            if (timeManager.season == TimeManager.Season.Winter) { seasonString = "������  ����  �ܿ���  �Խ��ϴ�."; }

            seasonText.SetText(seasonString);
        }
    }
}
