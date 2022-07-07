using System.Collections.Generic;
using Core;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] List<PoolableMono> poolingList = new List<PoolableMono>();
    private Transform pooler = null;
    private void Awake()
    {
        pooler = transform.GetChild(0);
        if(pooler == null) return;
        foreach(PoolableMono prefab in poolingList)
            PoolManager.Instance.CreatePool(prefab, pooler);
    }
}
