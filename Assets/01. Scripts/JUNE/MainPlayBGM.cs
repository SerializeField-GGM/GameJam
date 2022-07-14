using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JUNSUNG;

namespace JUNE
{
    public class MainPlayBGM : MonoBehaviour
    {
        [SerializeField] AudioClip mainBGM;
        void OnEnable()
        {
            BGMControll.Instance.PlayButtonSound(mainBGM);
        }
    }
}
