using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

namespace Core
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance = null;

        [Serializable]
        public enum Season
        {
            Spring = 0,
            Summer = 1,
            Fall = 2,
            Winter = 3,
        }

        [SerializeField] UnityEvent doSlideleft, doPopup, doSlideright, doPopdown;
        [SerializeField] long balancing = 1000;
        public float currentTime = 0;
        public float delay = 900;
        public Season season = Season.Spring;
        public bool onChanging = false;
        private StudentData std = null;
        private SchoolData sd = null;
        public int inFameAm = 0;
        public long inMoneyAm = 0;
        public int inStudentAm = 0;

        private void Awake()
        {
            //PlayerPrefs.DeleteAll();
            if (Instance == null) Instance = this;

            string JSON = PlayerPrefs.GetString("SeasonJSON", null);

            if(JSON.Length == 0) season = Season.Spring;
            else season = JsonUtility.FromJson<Season>(JSON);

            currentTime = PlayerPrefs.GetFloat("CurrentTime", 0);
        }

        private void OnDisable()
        {
            string JSON = JsonUtility.ToJson(season);
            PlayerPrefs.SetString("SeasonJSON", JSON);
            PlayerPrefs.SetFloat("CurrentTime", currentTime);
            PlayerPrefs.DeleteAll();
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
                inMoneyAm = sd.fame * balancing;
                MoneyManager.Instance.SetMoney(inMoneyAm);
                if (season == Season.Winter)
                {
                    if(std.talent > 40) inFameAm = (int)(std.count * 0.002f);
                    else inFameAm = -(int)(std.count * 0.002f);
                    inStudentAm = (int)(sd.fame * 0.6f);
                    FameManager.Instance.SetFame(inFameAm);
                    StudentState.Instance.AddStudent(inStudentAm);
                    StudentState.Instance.AddStress(-std.stress);
                    StudentState.Instance.AddPassion(-std.passion + 30);
                    StudentState.Instance.AddTalent(-std.talent);
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
