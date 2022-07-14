using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace JUNSUNG
{
    public class BGMControll : MonoBehaviour
    {
        public static BGMControll Instance=  null;

        private Slider slider = null;
        private AudioSource BGMAudioSource = null;

        private void Awake()
        {
            if(Instance == null) Instance = this;

            DontDestroyOnLoad(this);
            slider = GetComponent<Slider>(); 
            BGMAudioSource = GameObject.Find("BGMSoundPlayer").GetComponent<AudioSource>();
        }

        public void VolumeControll(AudioSource audioSource)
        {
            BGMAudioSource.volume = slider.value;
        }

        public void PlayButtonSound(AudioClip clip)
        {
            BGMAudioSource.clip = clip;
            BGMAudioSource.Stop();
            BGMAudioSource.Play();
        }
    }
}
