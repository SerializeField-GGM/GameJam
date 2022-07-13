using Core;
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

        private bool isOver = false;

        private void OnEnable()
        {
            scraps.SetActive(true);
            ramen.SetActive(true);
            smell.SetActive(true);
            soup.SetActive(true);
        }

        void Update()
        {
            if(smell.activeSelf == false && ramen.activeSelf == false && soup.activeSelf == false && scraps.activeSelf == false && !isOver)
            {
                isOver = true;
                clearText.SetActive(true);
                StudentState.Instance.AddStress(-3);
                Time.timeScale = 0;
            }

            if(time.fillAmount == 1 && !isOver && (smell.activeSelf != false || ramen.activeSelf != false || soup.activeSelf != false || scraps.activeSelf != false))
            {
                isOver = true;
                failText.SetActive(true);
                StudentState.Instance.AddStress(+3);
                Time.timeScale = 0;
            }
        }
    }
}
