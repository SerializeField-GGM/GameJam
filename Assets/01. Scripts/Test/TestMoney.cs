using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JUNE;

namespace Test
{
    public class TestMoney : MonoBehaviour
    {
        [SerializeField] MoneyManager moneyManager;
        public void OnClick123123()
        {
            moneyManager.GetMoney(1);
        }
    }
}
