using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JUNSUNG;

namespace JUNE
{
    public class ProgrammingMGBGM : MonoBehaviour
    {
        [SerializeField]AudioClip programmingBGMSound;
        void Start()
        {
            BGMControll.Instance.PlayButtonSound(programmingBGMSound);
        }
    }
}