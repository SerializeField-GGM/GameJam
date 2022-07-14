using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance = null;

        [SerializeField] List<PoolableMono> poolingList;
   
        private Dictionary<string, Pools<PoolableMono>> pools = new Dictionary<string, Pools<PoolableMono>>();

        void Awake()
        {
            if(Instance == null)
                Instance = this;

            foreach(PoolableMono prefab in poolingList)
                PoolManager.Instance.CreatePool(prefab, transform);
        }
         
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
