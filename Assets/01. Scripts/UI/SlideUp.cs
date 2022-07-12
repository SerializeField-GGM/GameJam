using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class SlideUp : MonoBehaviour
    {
        [SerializeField] float endVal, duration;
        public void DoSlideUp(RectTransform rt)
        {
            rt.DOLocalMoveY(endVal, duration).SetEase(Ease.Linear);
        }
    }
}
