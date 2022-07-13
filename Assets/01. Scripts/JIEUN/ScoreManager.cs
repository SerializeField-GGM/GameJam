using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace JIEUN
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;

        public int dustCount = 0;
        [SerializeField] Text countText = null;

        private void Awake() 
        {
            if(Instance == null)
            Instance = this;
        }

        void Update()
        {
            ScoreCount();
            Debug.Log(dustCount);
        }

        void ScoreCount()
        {
            countText.text = ": " + dustCount;
        }
    }
}
