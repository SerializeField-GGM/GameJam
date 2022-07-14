using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace JUNSUNG
{
    public class SoundControll : MonoBehaviour
    {
        public static SoundControll Instance = null;

        private Slider slider = null;
        private AudioSource effectAudioSource = null;

        private void Awake()
        {
            if(Instance == null)
             Instance = this;

            DontDestroyOnLoad(this);
            slider = GetComponent<Slider>(); 
            effectAudioSource = GameObject.Find("EffectSoundPlayer").GetComponent<AudioSource>();
        }

        public void VolumeControll(AudioSource audioSource)
        {
            audioSource.volume = slider.value;
        }

        public void PlayButtonSound(AudioClip clip)
        {
            effectAudioSource.clip = clip;
            effectAudioSource.Stop();
            effectAudioSource.Play();
        }
    }
}
