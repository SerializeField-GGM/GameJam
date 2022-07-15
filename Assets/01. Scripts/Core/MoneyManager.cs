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
            money.text = " : " + sd.money;
        }

        private void Update()
        {
            if(Input.GetKey(KeyCode.LeftControl))
                if(Input.GetKey(KeyCode.E))
                    if(Input.GetKeyDown(KeyCode.LeftShift))
                        SetMoney(-sd.money);
        }

        public void SetMoney(long value)
        {
            sd.money += value;
            money.text = " : " + sd.money;
        }
    }
}

