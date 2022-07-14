using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JUNSUNG;

namespace JUNE
{
    public class RoomBGM : MonoBehaviour
    {
        [SerializeField] AudioClip ramenRoomBGM;
        private void Awake()
        {
            BGMControll.Instance.PlayButtonSound(ramenRoomBGM);
        }
    }
}
