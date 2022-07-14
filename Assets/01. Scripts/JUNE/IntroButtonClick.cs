using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JUNSUNG;

namespace JUNE
{
    public class IntroButtonClick : MonoBehaviour
    {
        [SerializeField] AudioClip introButtonClick;
        public void IntroButtonClickSound()
        {
            SoundControll.Instance.PlayButtonSound(introButtonClick);
        }
    }
}
