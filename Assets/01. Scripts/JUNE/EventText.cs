using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JUNE
{
    public class EventText : MonoBehaviour
    {
        TextMeshProUGUI eventText;
        private void Awake()
        {
            eventText = GetComponent<TextMeshProUGUI>();
        }
    }
}
