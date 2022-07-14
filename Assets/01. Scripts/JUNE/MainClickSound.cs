using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JUNSUNG;

namespace JUNE
{
    public class MainClickSound : MonoBehaviour
    {
        [SerializeField] AudioClip SlideAudio;
        [SerializeField] AudioClip ShopClickAudio;
        [SerializeField] AudioClip ButtonClickAudio;
        public void ShopClick()
        {
            SoundControll.Instance.PlayButtonSound(ShopClickAudio);
        }
        public void SlideClick()
        {
            SoundControll.Instance.PlayButtonSound(SlideAudio);
        }
        public void ButtonClick()
        {
            SoundControll.Instance.PlayButtonSound(ButtonClickAudio);
        }
    }
}
