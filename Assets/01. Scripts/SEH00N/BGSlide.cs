using DG.Tweening;
using UnityEngine;
using UI;

namespace SEH00N
{
    public class BGSlide : Buttons
    {
        [SerializeField] RectTransform lastPanel;
        [SerializeField] RectTransform rt;
        [SerializeField] float duration;
        [SerializeField] int maxVal;
        private bool onSlide = false;
        public void SlideLeft()
        {
            if(onSlide || rt.localPosition.x >= 0) { Init(); return; }
            onSlide = true;
            rt.DOLocalMoveX(rt.localPosition.x + 1920, duration).SetEase(Ease.Linear).OnComplete(() => onSlide = false);
            Init();
        }

        public void SlideRight()
        {
            if(onSlide || rt.localPosition.x <= -lastPanel.localPosition.x) { Init(); return; }
            onSlide = true;
            rt.DOLocalMoveX(rt.localPosition.x - 1920, duration).SetEase(Ease.Linear).OnComplete(() => onSlide = false);
            Init();
        }
    }
}
