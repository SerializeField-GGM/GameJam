using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;

        [SerializeField] List<PoolableMono> poolingList;
        public GameObject main;
        public Transform pooler = null;
        private void Awake()
        {
            if(Instance == null) Instance = this;

            pooler = transform.GetChild(0);
            if(pooler == null) return;

            if(PoolManager.Instance == null) 
                PoolManager.Instance = new PoolManager();

            foreach(PoolableMono prefab in poolingList)
                PoolManager.Instance.CreatePool(prefab, pooler);
            
            if(SceneLoader.Instance == null)
                SceneLoader.Instance = new SceneLoader();
        }
    }   
}