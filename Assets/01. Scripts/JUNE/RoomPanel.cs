using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JUNE
{
    public class RoomPanel : MonoBehaviour
    {
        [SerializeField] GameObject broom;
        [SerializeField] GameObject scraps;
        [SerializeField] GameObject ramen;
        [SerializeField] GameObject cabinet;
        [SerializeField] GameObject soup;
        [SerializeField] GameObject trashcan;
        [SerializeField] GameObject febreeze;
        [SerializeField] GameObject smell;
        [SerializeField] GameObject door;
        [SerializeField] GameObject openDoor;
        [SerializeField] Image time;
        [SerializeField] GameObject clearText;
        [SerializeField] GameObject failText;

        private void OnEnable()
        {
            scraps.SetActive(true);
            ramen.SetActive(true);
            smell.SetActive(true);
            soup.SetActive(true);
        }

        void Update()
        {
            if(smell.activeSelf == false && ramen.activeSelf == false && soup.activeSelf == false && scraps.activeSelf == false)
            {
                clearText.SetActive(true);
                Time.timeScale = 0;
            }

            if(time.fillAmount == 1 && (smell.activeSelf != false || ramen.activeSelf != false || soup.activeSelf != false || scraps.activeSelf != false))
            {
                failText.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
