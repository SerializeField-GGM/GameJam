using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using Core;
using System.Collections;

namespace JIEUN
{
    public class CleanManager : MonoBehaviour
    {
        [SerializeField] PoolableMono dust = null;
        [SerializeField] Transform min, max;
        [SerializeField] GameObject scorePanel = null;
        [SerializeField] Slider timer = null;
        [SerializeField] float currentTime = 0;
        [SerializeField] float maxTime = 25;
        public int i ;//{ get; set; }s
        private Transform canvas;
        private Camera cam = null;

        public static CleanManager Instance;

        private void Awake() {
            if(Instance == null)
                Instance = this;

            canvas = GameObject.Find("Canvas").transform;
            cam = Camera.main;
        }

        private void Update() 
        {
            if(currentTime < maxTime)
                currentTime += Time.deltaTime;
    
            
            timer.value = currentTime / maxTime;
        }

        private void Start() {
            StartCoroutine(Spawn());
        }
        IEnumerator Spawn()
        {
            while(true)
            {
                if(i < 7)
                {
                    PoolableMono temp = PoolManager.Instance.Pop(dust);
                    temp.transform.SetParent(canvas);
                    temp.transform.position = cam.WorldToScreenPoint(new Vector3(Random.Range(min.position.x, max.position.x),
                    Random.Range(min.position.y, max.position.y)));
                    i++;
                    yield return new WaitForSeconds(1f);
                }
                yield return null;
            }
        }
    }
}
