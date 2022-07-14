using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JUNSUNG
{
    public class IntroSoundControll : MonoBehaviour
    {
        [SerializeField] private AudioSource introEffectSoundPlayer = null;

        public void PlaySound(AudioClip clip)
        {
            introEffectSoundPlayer.Stop();
            introEffectSoundPlayer.clip = clip;
            introEffectSoundPlayer.Play();
        }
    }
}
