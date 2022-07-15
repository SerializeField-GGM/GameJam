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

        private void Update()
        {
            if(Input.GetKey(KeyCode.LeftControl))
                if(Input.GetKey(KeyCode.W))
                    if(Input.GetKeyDown(KeyCode.LeftShift))
                        SetFame(-sd.fame);
            if(Input.GetKey(KeyCode.LeftControl))
                if(Input.GetKey(KeyCode.Z))
                    if(Input.GetKeyDown(KeyCode.LeftShift))
                        SetFame(30);
        }

        void Start()
        {
            sd = DataManager.Instance.sd;
            fame.text = " : " + sd.fame;
        }

        public void SetFame(long value)
        {
            sd.fame += value;
            fame.text = " : " + sd.fame;
        }
    }
}
