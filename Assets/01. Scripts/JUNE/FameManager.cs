using Core;
using UnityEngine;
using TMPro;

namespace JUNE
{
    public class FameManager : MonoBehaviour
    {
        TextMeshProUGUI fame;
        private SchoolData sd = null;

        private void Awake()
        {
            fame = GetComponent<TextMeshProUGUI>();
        }

        void Start()
        {
            sd = DataManager.Instance.sd;
            fame.text = "명성 : " + sd.fame;
        }

        public void MinusFame(long minusFame)
        {
            sd.fame -= minusFame;
            fame.text = "명성 : " + sd.fame;
        }

        public void GetFame(long getFame)
        {
            sd.fame += getFame;
            fame.text = "명성  : " + sd.fame;
        }
    }
}
