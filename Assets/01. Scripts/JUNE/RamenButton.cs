using Core;
using UnityEngine;

namespace JUNE
{
    public class RamenButton : MonoBehaviour
    {
        [SerializeField] GameObject eatingPanel;
        [SerializeField] GameObject roomPanel;
        [SerializeField] GameObject eatUpPanel;
        [SerializeField] GameObject clearPanel;
        [SerializeField] GameObject failPanel;
        public void OnClickReturn()
        {
            eatingPanel.SetActive(false);
            eatUpPanel.SetActive(false);
            failPanel.SetActive(false);
            clearPanel.SetActive(false);
            roomPanel.SetActive(false);
            Time.timeScale = 1;
            GameManager.Instance.main.SetActive(true);
            SceneLoader.Instance.RemoveScene("RAMEN");
        }
    }
}
