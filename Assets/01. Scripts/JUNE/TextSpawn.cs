using TMPro;
using UnityEngine;
using Core;

namespace JUNE
{
    public class TextSpawn : MonoBehaviour
    {
        [SerializeField] PoolableMono stress;
        [SerializeField] PoolableMono passion;
        [SerializeField] PoolableMono ability;
        private Camera cam = null;

        private void Awake()
        {
            cam = Camera.main;
        }
        public void SpawnAblity(string value, Vector3 Pos)
        {
            PoolableMono temp = PoolManager.Instance.Pop(stress);
            temp.transform.position = Pos;
            TextMeshProUGUI text = temp.GetComponentInChildren<TextMeshProUGUI>();
            text.text = value;
        }

        public void SpawnPassion(string value, Vector3 Pos)
        {
            PoolableMono temp = PoolManager.Instance.Pop(passion);
            temp.transform.position = Pos;
            TextMeshProUGUI text = temp.GetComponentInChildren<TextMeshProUGUI>();
            text.text = value;
        }

        public void SpawnStress(string value, Vector3 Pos)
        {
            PoolableMono temp = PoolManager.Instance.Pop(ability);
            temp.transform.position = Pos;
            TextMeshProUGUI text = temp.GetComponentInChildren<TextMeshProUGUI>();
            text.text = value;
        }
    }
}
