using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace JUNSUNG
{
    public class SoundControll : MonoSingleton<SoundControll>
    {
        private Slider slider = null;
        private AudioSource effectAudioSource = null;

        private void Awake()
        {
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
