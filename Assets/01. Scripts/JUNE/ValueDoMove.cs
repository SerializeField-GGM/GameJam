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
        RectTransform rt;
        Image image;
        private void Awake()
        {
            transform.parent = GameObject.Find("TextCanvas").transform;
            image = GetComponent<Image>();
            rt = GetComponent<RectTransform>();
        }
        private void OnEnable()
        {
            Color c = image.color;
            c.a = 1;
            image.color = c;

            rt.DOLocalMoveY(rt.localPosition.y,1f);
            StartCoroutine(Disappear());
        }

        IEnumerator Disappear()
        {
            float currentTime = 0;
            float percent = 0;
            while(percent < 1)
            {
                currentTime += Time.deltaTime;
                percent = currentTime / 1;

                Color c = image.color;
                c.a = 1 - percent;
                image.color = c;
                yield return null;
            }
            yield return new WaitForSeconds(0.001f);
            PoolManager.Instance.Push(GetComponent<PoolableMono>());
        }
    }
}
