using Core;
using UnityEngine;

namespace Test
{
    public class TestPrefab : PoolableMono
    {
        public override void Reset()
        {
            Debug.Log(123);
            Invoke("Dead", 1f);
        }

        private void Dead()
        {
            PoolManager.Instance.Push(this);
        }
    }
}
