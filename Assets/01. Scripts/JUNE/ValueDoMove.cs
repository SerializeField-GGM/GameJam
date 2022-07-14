using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Core;

namespace JUNE
{
    public class ValueDoMove : MonoBehaviour
    {
        [SerializeField] Transform trm;
        Camera cam = null;
        RectTransform rt;
        Image image;
        private void Awake()
        {
            trm =  GameObject.Find("TextSpawnPos").transform;
            cam = Camera.main;
            //image = GetComponent<Image>();
            rt = GetComponent<RectTransform>();
        }
        private void OnEnable()
        {
            transform.parent = GameObject.Find("TextCanvas").transform;
            rt.localPosition = new Vector3(0, 100);
            //image.color = Color.white;
            rt.DOLocalMove(new Vector3(0, transform.localPosition.y + 100), 2f);
            StartCoroutine(Disappear());
        }

        IEnumerator Disappear()
        {
            // float currentTime = 0;
            // float percent = 0;
            // while(percent < 1)
            // {
            //     currentTime += Time.deltaTime;
            //     percent = currentTime / 3;

            //     Color c = image.color;
            //     c.a = 1 - percent;
            //     image.color = c;
            //     yield return null;
            // }
            yield return new WaitForSeconds(2f);
            transform.SetParent(GameManager.Instance.pooler);
            PoolManager.Instance.Push(GetComponent<PoolableMono>());
        }
    }
}
