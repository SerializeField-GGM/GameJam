using Core;
using UnityEngine;
using UnityEngine.UI;
using UI;

namespace SEH00N
{
    public class FacilitiesData : Buttons
    {
        [SerializeField] string facilitieName;
        [SerializeField] long fame, cost;
        private SchoolData sd = null;

        private void Start()
        {
            sd = DataManager.Instance.sd;
            if(sd.facilities.Contains(facilitieName))
                GetComponentInChildren<Button>().interactable = false;
        }
        
        public void Buy()
        {
            if(sd.money >= cost)
            {
                MoneyManager.Instance.SetMoney(-cost);
                FameManager.Instance.SetFame(fame);
                sd.facilities.Add(facilitieName);
                GetComponentInChildren<Button>().interactable = false;
                Init();
            }
        }
    }
}
