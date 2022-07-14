using Core;
using UnityEngine;
using UnityEngine.UI;
using UI;
using JUNSUNG;

namespace SEH00N
{
    public class FacilitiesData : Buttons
    {
        [SerializeField] string facilitieName;
        [SerializeField] long fame, cost;
        [SerializeField] AudioClip shopBuyAudio;
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
                SoundControll.Instance.PlayButtonSound(shopBuyAudio);
                MoneyManager.Instance.SetMoney(-cost);
                FameManager.Instance.SetFame(fame);
                sd.facilities.Add(facilitieName);
                GetComponentInChildren<Button>().interactable = false;
                Init();
            }
        }
    }
}
