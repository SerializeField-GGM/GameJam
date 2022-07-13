using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Core
{
    public class TimeManager : MonoSingleton<TimeManager>
    {
        public enum Season
        {
            Spring = 0,
            Summer = 1,
            Fall = 2,
            Winter = 3,
        }

        [SerializeField] long balancing = 1000;
        [SerializeField] float delay = 900;
        [SerializeField] UnityEvent doSlideleft, doPopup, doSlideright, doPopdown;
        public Season season = Season.Spring;
        [SerializeField] float currentTime = 0;
        private bool onChanging = false;

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
                MoneyManager.Instance.SetMoney(DataManager.Instance.sd.fame * balancing);
                if (season == Season.Winter) { season = 0; return; }
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
