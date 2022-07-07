using Core;
using UnityEngine;

namespace Test
{
    public class TestPooling : MonoBehaviour
    {
        [SerializeField] PoolableMono prefab ;

        private void Update()
        {
            if(Input.GetButtonDown("Jump"))
                PoolManager.Instance.Pop(prefab);
        }
    }
}
