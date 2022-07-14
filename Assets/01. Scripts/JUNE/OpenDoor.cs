using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JUNSUNG;

namespace JUNE
{
    public class OpenDoor : MonoBehaviour
    {
        [SerializeField] AudioClip _opendoor;
        
        private void OnEnable()
        {
            SoundControll.Instance.PlayButtonSound(_opendoor);
        }
    }
}
