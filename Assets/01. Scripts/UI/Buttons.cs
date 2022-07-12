using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Buttons : MonoBehaviour
    {
        protected void Init()
        {
            Button button = GetComponent<Button>();
            button.interactable = false;
            button.interactable = true;
        }
    }
}
