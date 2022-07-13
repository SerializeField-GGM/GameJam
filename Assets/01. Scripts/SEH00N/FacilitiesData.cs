using Core;
using UnityEngine;
using UnityEngine.UI;
using JUNE;

namespace SEH00N
{
    public class FacilitiesData : MonoBehaviour
    {
        [SerializeField] string facilitieName;
        [SerializeField] long fame, cost;
        private SchoolData sd = null;
        private MoneyManager mm = null;
        private FameManager fm = null;

        private void Start()
        {
            sd = DataManager.Instance.sd;
            mm = GameObject.Find("Money").GetComponent<MoneyManager>();
            fm = GameObject.Find("Fame").GetComponent<FameManager>();
            if(sd.facilities.Contains(facilitieName))
                GetComponentInChildren<Button>().interactable = false;
        }
        
        public void Buy()
        {
            if(sd.money >= cost)
            {
                mm.SetMoney(cost);
                fm.GetFame(fame);
                sd.facilities.Add(facilitieName);
                GetComponentInChildren<Button>().interactable = false;
            }
        }
    }
}
