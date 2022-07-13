using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Buttons : MonoBehaviour
    {
        protected void Init()
        {
            Button button = GetComponent<Button>();
            if(button == null) return;
            button.interactable = false;
            button.interactable = true;
        }
    }
}
