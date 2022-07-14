using UnityEngine;
using TMPro;

namespace Core
{
    public class FameManager : MonoBehaviour
    {
        public static FameManager Instance = null;

        TextMeshProUGUI fame;
        private SchoolData sd = null;

        private void Awake()
        {
            if(Instance == null) Instance = this;
            fame = GetComponent<TextMeshProUGUI>();
        }

        void Start()
        {
            sd = DataManager.Instance.sd;
            fame.text = "명성 : " + sd.fame;
        }

        public void SetFame(long value)
        {
            sd.fame -= value;
            fame.text = "명성 : " + sd.fame;
        }
    }
}
