using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;

        public GameObject main;
        public Transform pooler = null;
        private void Awake()
        {
            if(Instance == null) Instance = this;

            pooler = transform.GetChild(0);

            if(SceneLoader.Instance == null)
                SceneLoader.Instance = new SceneLoader();
        }
    }   
}