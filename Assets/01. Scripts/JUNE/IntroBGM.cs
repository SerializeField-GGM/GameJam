using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JUNSUNG;

namespace JUNE
{
    public class IntroBGM : MonoBehaviour
    {
        [SerializeField] AudioClip introBGMSound;
        private void Start()
        {
            BGMControll.Instance.PlayButtonSound(introBGMSound);
        }
    }
}
