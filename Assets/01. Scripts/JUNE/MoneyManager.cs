using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JUNE
{
    public class MoneyManager : MonoBehaviour
    {
        private int totalmoney = 0;
        public int Totalmoney => totalmoney;
        TextMeshProUGUI money;

        private void Awake()
        {
            money = GetComponent<TextMeshProUGUI>();
        }

        void Start()
        {
            money.text = "Money : " + totalmoney;
        }

        public void UseMoney(int useMoney)
        {
            totalmoney -= useMoney;
            money.text = "Money : " + totalmoney;
        }

        public void GetMoney(int getMoney)
        {
            totalmoney += getMoney;
            money.text = "Money : " + totalmoney;
        }
    }
}
