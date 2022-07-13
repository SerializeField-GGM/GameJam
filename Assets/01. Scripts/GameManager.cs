using System.Collections.Generic;
using Core;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    [SerializeField] List<PoolableMono> poolingList = new List<PoolableMono>();
    private Transform pooler = null;
    private void Awake()
    {
        if(Instance == null) Instance = this;

        PoolManager.Instance = new PoolManager();

        pooler = transform.GetChild(0);
        if(pooler == null) { return; }
        foreach(PoolableMono prefab in poolingList)
            PoolManager.Instance.CreatePool(prefab, pooler);
    }
}
