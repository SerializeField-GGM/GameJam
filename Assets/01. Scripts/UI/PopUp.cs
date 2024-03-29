using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class PopUp : Buttons
    {
        [SerializeField] RectTransform contents, contents2;
        [SerializeField] float duration;
        public void DoPopUp(RectTransform rt)
        {
            if(contents != null) contents.localPosition = new Vector3(2912, contents.localPosition.y);
            rt.localScale = Vector3.zero;
            rt.gameObject.SetActive(true);
            rt.DOScale(Vector3.one, duration);
            Init();
        }

        public void DoPopDown(RectTransform rt)
        {
            Time.timeScale = 1;
            rt.DOScale(Vector3.zero, duration);//.OnComplete(() => rt.gameObject.SetActive(false));
            Init();
        }
    }
}
