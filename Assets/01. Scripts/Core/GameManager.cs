using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] List<PoolableMono> poolingList = new List<PoolableMono>();
        public GameObject main;
        private Transform pooler = null;
        private void Awake()
        {
            pooler = transform.GetChild(0);
            if(pooler == null) return;
            foreach(PoolableMono prefab in poolingList)
                PoolManager.Instance.CreatePool(prefab, pooler);
            
            if(SceneLoader.Instance == null)
                SceneLoader.Instance = new SceneLoader();
        }
    }   
}
