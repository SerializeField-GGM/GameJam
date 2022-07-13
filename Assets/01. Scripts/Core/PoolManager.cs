using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PoolManager
    {
        public static PoolManager Instance = null;
        private Dictionary<string, Pools<PoolableMono>> pools = new Dictionary<string, Pools<PoolableMono>>();

        public void CreatePool(PoolableMono prefab, Transform parent)
        {
            if(pools.ContainsKey(prefab.name)) { Debug.Log($"키 중복"); return; }
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
