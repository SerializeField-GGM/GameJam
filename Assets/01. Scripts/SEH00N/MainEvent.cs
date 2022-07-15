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
        protected TextMeshProUGUI eventText;
        protected Button button = null;
        protected int temp = 0;
        private void Awake()
        {
            //PlayerPrefs.DeleteAll();
            button = GetComponent<Button>();
            eventText = GameObject.Find("EventText").GetComponent<TextMeshProUGUI>();
        }

        private void OnDisable()
        {
            //PlayerPrefs.DeleteAll();
        }

        private void Update()
        {
            if (temp == 1 || TimeManager.Instance.season != season)
                button.interactable = false;

            if(temp == 0 && TimeManager.Instance.season == season)
                button.interactable = true;

            if(Input.GetKey(KeyCode.LeftControl))
                if(Input.GetKey(KeyCode.R))
                    if(Input.GetKeyDown(KeyCode.LeftShift))
                        temp = 0;
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
                temp = 0;
                button.interactable = true;
            }
            else
            {
                temp = 1;
                button.interactable = false;
            }
        }

        protected void OnClick()
        {
            temp = 1;
            button.interactable = false;
        }
    }
}
