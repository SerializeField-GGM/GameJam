using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class PopUp : MonoBehaviour
    {
        [SerializeField] Vector3 endVal;
        [SerializeField] float duration;
        public void DoPopUp(RectTransform rt)
        {
            rt.DOScale(endVal, duration);
        }
    }
}
