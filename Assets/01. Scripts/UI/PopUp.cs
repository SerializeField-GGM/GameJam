using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class PopUp : Buttons
    {
        [SerializeField] float duration;
        public void DoPopUp(RectTransform rt)
        {
            rt.localScale = Vector3.zero;
            rt.gameObject.SetActive(true);
            rt.DOScale(Vector3.one, duration);
            Init();
        }

        public void DoPopDown(RectTransform rt)
        {
            rt.DOScale(Vector3.zero, duration).OnComplete(() => rt.gameObject.SetActive(false));
            Init();
        }
    }
}
