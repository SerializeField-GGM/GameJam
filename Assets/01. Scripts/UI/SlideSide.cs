using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class SlideSide : MonoBehaviour
    {
        [SerializeField] float duration;

        public void DoSlideLeft(RectTransform rt)
        {
            Sequence seq = DOTween.Sequence();

            seq.Append(rt.DOLocalMoveX(0, duration - 0.5f)).SetEase(Ease.InBack);
            seq.Append(rt.DOLocalMoveX(0, 0.5f)).SetEase(Ease.Linear);
        }

        public void DoSlideRight(RectTransform rt)
        {
            Sequence seq = DOTween.Sequence();

            seq.Append(rt.DOLocalMoveX(1920, duration - 0.5f)).SetEase(Ease.InBack);
            seq.Append(rt.DOLocalMoveX(1920, 0.5f)).SetEase(Ease.Linear);
        }
    }
}
