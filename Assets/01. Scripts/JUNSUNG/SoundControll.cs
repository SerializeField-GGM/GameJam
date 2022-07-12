using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JUNSUNG
{
    public class SoundControll : MonoBehaviour
    {
        private Slider slider = null;
        private AudioSource buttonAudioSource = null;

        private void Awake()
        {
            slider = GetComponent<Slider>(); 
            buttonAudioSource = GameObject.Find("EffectSoundPlayer").GetComponent<AudioSource>();
        }

        public void VolumeControll(AudioSource audioSource)
        {
            audioSource.volume = slider.value;
        }

        public void PlayButtonSound()
        {
            buttonAudioSource.Stop();
            buttonAudioSource.Play();
        }
    }
}
