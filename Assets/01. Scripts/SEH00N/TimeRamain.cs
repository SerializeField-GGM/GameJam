using Core;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace SEH00N
{
    public class TimeRamain : MonoBehaviour
    {
        [SerializeField] float limitTime;
        private GameObject endPanel = null;
        private TextMeshProUGUI moneyText = null;
        private TMP_InputField inputField = null;
        private Slider slider = null;
        private float currentTime = 0;
        private int getMoney = 0;
        private bool isEnd = false;

        private void Awake()
        {
            inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
            slider = GetComponent<Slider>();
            endPanel = GameObject.Find("EndPanel");
            moneyText = endPanel.transform.Find("MoneyText").GetComponent<TextMeshProUGUI>();
            endPanel.SetActive(false);
        }

        private void Update()
        {
            currentTime += Time.deltaTime;
            slider.value = (limitTime - currentTime) / limitTime;
            if(slider.value <= 0 && !isEnd)
            {
                isEnd = true;
                endPanel.SetActive(true);
                inputField.interactable = false;
                getMoney = ScoreManager.Instance.score * 300;
                MoneyManager.Instance.SetMoney(getMoney);
                moneyText.text = $"{getMoney}원 획득";
            }
        }
    }
}
