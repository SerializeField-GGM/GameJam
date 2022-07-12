using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class SlideUp : Buttons
    {
        [SerializeField] float endVal, duration;
        public void DoSlideUp(RectTransform rt)
        {
            rt.DOLocalMoveY(endVal, duration).SetEase(Ease.Linear);
            Init();
        }
    }
}
