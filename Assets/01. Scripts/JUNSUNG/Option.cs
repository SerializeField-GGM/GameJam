using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace JUNSUNG
{
    public class Option : MonoBehaviour
    {
        //UIManager�� �Űܾ��ҵ�

        private RectTransform rt;

        private bool optionActive = false;

        private void Awake()
        {
            rt = GetComponent<RectTransform>();
        }

        void Update()
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                if(!optionActive)
                    rt.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.Linear).OnComplete(() => { optionActive = true; /*Time.timeScale = 0;*/});
                if(optionActive)
                    rt.DOScale(new Vector3(0, 0, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() => { optionActive = false; });
            }
            // if(Input.GetKeyUp(KeyCode.Escape) && optionActive)
            // {
            //     //Time.timeScale = 1;
            //     rt.DOScale(new Vector3(0, 0, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() => { optionActive = false; });
            // }
        }
    }
}
