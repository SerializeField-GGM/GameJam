using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PoolManager : MonoSingleton<PoolManager>
    {
        private Dictionary<string, Pools<PoolableMono>> pools = new Dictionary<string, Pools<PoolableMono>>();

        public void CreatePool(PoolableMono prefab, Transform parent)
        {
            Pools<PoolableMono> pool = new Pools<PoolableMono>(prefab, parent);
            pools.Add(prefab.name, pool);
        }

        public PoolableMono Pop(PoolableMono prefab)
        {
            return pools[prefab.name].Pop();
        }

        public void Push(PoolableMono prefab)
        {
            pools[prefab.name].Push(prefab);
        }
    }
}
