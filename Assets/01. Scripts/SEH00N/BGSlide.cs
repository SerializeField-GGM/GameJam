using DG.Tweening;
using UnityEngine;
using UI;

namespace SEH00N
{
    public class BGSlide : Buttons
    {
        [SerializeField] RectTransform rt;
        [SerializeField] float duration;
        private bool onSlide = false;
        public void SlideLeft()
        {
            if(onSlide) return;
            onSlide = true;
            rt.DOLocalMoveX(rt.localPosition.x + 1920, duration).SetEase(Ease.Linear).OnComplete(() => onSlide = false);
            Init();
        }

        public void SlideRight()
        {
            if(onSlide) return;
            onSlide = true;
            rt.DOLocalMoveX(rt.localPosition.x - 1920, duration).SetEase(Ease.Linear).OnComplete(() => onSlide = false);
            Init();
        }
    }
}
