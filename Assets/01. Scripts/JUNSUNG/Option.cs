using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace JUNSUNG
{
    public class Option : MonoBehaviour
    {
        //UIManager로 옮겨야할듯

        private RectTransform rt;

        private bool optionActive = false;

        private void Awake()
        {
            rt = GetComponent<RectTransform>();
        }

        void Update()
        {
            if(Input.GetKeyUp(KeyCode.Escape) && !optionActive)
            {
                rt.DOScale(new Vector3(1, 1, 1), 0.5f).OnComplete(() => { optionActive = true; });
                
            }
            else if(Input.GetKeyUp(KeyCode.Escape) && optionActive)
            {
                rt.DOScale(new Vector3(0, 0, 0), 0.5f).OnComplete(() => { optionActive = false; }); ;
            }
        }
    }
}
