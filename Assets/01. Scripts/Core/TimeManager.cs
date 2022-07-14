using System.Globalization;
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Core
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance = null;

        public enum Season
        {
            Spring = 0,
            Summer = 1,
            Fall = 2,
            Winter = 3,
        }

        [SerializeField] long balancing = 1000;
        public float currentTime = 0;
        public float delay = 900;
        [SerializeField] UnityEvent doSlideleft, doPopup, doSlideright, doPopdown;
        public Season season = Season.Spring;
        public bool onChanging = false;
        private StudentData std = null;
        private SchoolData sd = null;

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        private void Start()
        {
            std = DataManager.Instance.std;
            sd = DataManager.Instance.sd;
        }

        private void Update()
        {
            SetSeason();
        }

        public void NextButton()
        {
            onChanging = false;
            StartCoroutine(NextCorountine());
        }

         private void SetSeason()
        {
            if (onChanging) return;
            currentTime += Time.deltaTime;
            if (currentTime >= delay)
            {
                StartCoroutine(ChangeSeason());
                onChanging = true;
                currentTime = 0;
                MoneyManager.Instance.SetMoney(sd.fame * balancing);
                if (season == Season.Winter)
                {
                    if(std.talent > 40) FameManager.Instance.SetFame((int)(std.count * 0.002f));
                    else FameManager.Instance.SetFame(-(int)(std.count * 0.002f));
                    StudentState.Instance.AddStudent((int)(sd.fame * 0.6f)); 
                    season = 0; return;
                }
                season++;
            }
        }

        private IEnumerator NextCorountine()
        {
            doPopdown?.Invoke();
            yield return new WaitForSeconds(0.5f);
            doSlideright?.Invoke();
        }

        private IEnumerator ChangeSeason()
        {
            doSlideleft?.Invoke();
            yield return new WaitForSeconds(1.5f);
            doPopup?.Invoke();
        }
    }
}
