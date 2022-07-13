using UnityEngine;
using TMPro;

namespace Core
{
    public class MoneyManager : MonoBehaviour
    {
        public static MoneyManager Instance = null;

        TextMeshProUGUI money;
        private SchoolData sd = null;

        private void Awake()
        {
            if(Instance == null) Instance = this;
            money = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            sd = DataManager.Instance.sd;
            money.text = "돈 : " + sd.money;
        }

        public void SetMoney(long value)
        {
            sd.money += value;
            money.text = "돈 : " + sd.money;
        }
    }
}

