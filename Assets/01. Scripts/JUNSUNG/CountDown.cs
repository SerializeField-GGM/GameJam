using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using DG.Tweening;
using UnityEngine.UI;

namespace JUNSUNG
{
    public class CountDown : MonoBehaviour
    {
        [SerializeField] private Sprite[] cntSprite = new Sprite[4];

        [SerializeField] private Image cntImage = null;
        private RectTransform cntImageTrm = null;

        [SerializeField] private float fadeTime = 1f;

        Vector3 cntImageInitPos;
        Color cntImageInitColor;

        public bool isStart = false;

        private void Awake()
        {
            cntImageTrm = cntImage.GetComponent<RectTransform>();

            cntImageInitPos = cntImageTrm.transform.position;
            cntImageInitColor = cntImage.color;
        }

        private void Start()
        {         
            StartCoroutine(FadeEffect(0, 1));
            Debug.Log(3);
        }

        IEnumerator FadeEffect(float start, float end)
        {
            float currentTime = 0;
            float percent = 0;
            Color color = cntImage.color;

            for (int i = 0; i < 4; i++)
            {
                yield return new WaitForSeconds(1);
                cntImage.sprite = cntSprite[i];
                cntImageTrm.DOMove(Camera.main.WorldToScreenPoint(new Vector3(0, 1.3f, 0)), 1);
                currentTime = 0;
                percent = 0;

                while (percent < 1)
                {
                    currentTime += Time.deltaTime;
                    percent = currentTime / fadeTime;

                    color.a = Mathf.Lerp(start, end, percent);
                    cntImage.color = color;

                    yield return null;
                }

                cntImageTrm.transform.position = cntImageInitPos;
                cntImage.color = cntImageInitColor;
            }

            isStart = true;
        }
    }
}
