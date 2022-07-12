using TMPro;
using UnityEngine;

namespace Test
{
    public class TestPrefabSpawner : MonoBehaviour
    {
        [SerializeField] GameObject textPrefab;
        [SerializeField] Transform canvas;
        private Camera cam = null;
        private void Awake()
        {
            cam = Camera.main;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                GameObject temp = Instantiate(textPrefab);
                TextMeshProUGUI text = temp.GetComponentInChildren<TextMeshProUGUI>();
                temp.transform.SetParent(canvas);
                temp.transform.position = cam.WorldToScreenPoint(transform.position);
                if(text == null) return;
                text.text = "123";
            }
        }
    }
}
