using UnityEngine.Events;
using UnityEngine;
using TMPro;
using Core;

namespace SEH00N
{
    public class NameInput : MonoBehaviour
    {
        [SerializeField] UnityEvent DoPopDown;
        private int i = 0;

        private void Awake()
        {
            i = PlayerPrefs.GetInt("IsSetted", 0);
            if(i == 0) Time.timeScale = 0;
            if(i == 1)
                gameObject.SetActive(false);
        }

        private void Update()
        {
            if(DataManager.Instance.sd.name != null)
            {
                i = 1;
                if(i == 1)
                DoPopDown?.Invoke();
                PlayerPrefs.SetInt("IsSetted", i);
            }
        }
    }
}
