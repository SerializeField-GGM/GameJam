using TMPro;
using UnityEngine;

namespace Core
{
    public class TextSpawn : MonoBehaviour
    {
        public static TextSpawn Instance = null;

        [SerializeField] PoolableMono textPrefab;
        private Camera cam = null;

        private void Awake()
        {
            if(Instance == null) Instance = this;
            cam = Camera.main;
        }

        public void SpawnText(string value, Vector3 Pos)
        {
            PoolableMono temp = PoolManager.Instance.Pop(textPrefab);
            TextMeshProUGUI text = temp.GetComponent<TextMeshProUGUI>();
            text.text = value;
        }
    }
}
