using System.Collections;
using TMPro;
using UI;
using Core;
using UnityEngine.UI;
using UnityEngine;

namespace SEH00N
{
    public class MainEvent : Buttons
    {
        [SerializeField] protected string positiveWriting, negativeWriting;
        [SerializeField] protected TimeManager.Season season;
        protected TimeManager.Season currentSeason;
        protected bool isPressed = false;
        protected TextMeshProUGUI eventText;
        protected Button button = null;
        protected int temp = 0;
        private void Awake()
        {
            //PlayerPrefs.DeleteAll();
            button = GetComponent<Button>();
            eventText = GameObject.Find("EventText").GetComponent<TextMeshProUGUI>();
        }
        private void Update()
        {
            if (isPressed || TimeManager.Instance.season != season)
                button.interactable = false;

            if(isPressed) temp = 1;
            else temp = 0;
        }
        private void LateUpdate()
        {
            if (TimeManager.Instance.onChanging)
            {
                StartCoroutine(SetButton());
            }
        }
        private IEnumerator SetButton()
        {
            yield return new WaitForSeconds(3f);
            if (TimeManager.Instance.season == season)
            {
                isPressed = false;
                button.interactable = true;
            }
            else
            {
                isPressed = true;
                button.interactable = false;
            }
        }

        protected void OnClick()
        {
            isPressed = true;
            button.interactable = false;
        }
    }
}
