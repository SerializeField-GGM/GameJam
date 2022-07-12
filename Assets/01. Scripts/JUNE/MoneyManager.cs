using UnityEngine;
using TMPro;
using Core;

namespace JUNE
{
    public class MoneyManager : MonoBehaviour
    {
        TextMeshProUGUI money;
        private SchoolData sd = null;

        private void Awake()
        {
            money = GetComponent<TextMeshProUGUI>();
        }

        void Start()
        {
            sd = DataManager.Instance.sd;
            money.text = "돈 : " + sd.money;
        }

        public void UseMoney(long useMoney)
        {
            sd.money -= useMoney;
            money.text = "돈 : " + sd.money;
        }

        public void GetMoney(long getMoney)
        {
            sd.money += getMoney;
            sd.money = (long)Mathf.Min(sd.money, 0);
            money.text = "돈 : " + sd.money;
        }
    }
}
