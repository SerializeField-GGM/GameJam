using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JUNE
{
    public class FameManager : MonoBehaviour
    {
        private int totalFame = 0;
        public int Totalmoney => totalFame;
        TextMeshProUGUI fame;

        private void Awake()
        {
            fame = GetComponent<TextMeshProUGUI>();
        }

        void Start()
        {
            fame.text = "Fame : " + totalFame;
        }

        public void MinusFame(int minusFame)
        {
            totalFame -= minusFame;
            fame.text = "Fame : " + totalFame;
        }

        public void GetFame(int getFame)
        {
            totalFame += getFame;
            fame.text = "Fame  : " + totalFame;
        }
    }
}
