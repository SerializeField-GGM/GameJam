using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] float duration;
    private RectTransform rt;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
        GameStart();
    }

    public void GameStart()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(rt.DOLocalMoveX(1920, duration - 0.5f)).SetEase(Ease.InBack);
        seq.Join(rt.GetComponent<Image>().DOFade(0, duration)).SetEase(Ease.Linear);
    }
}
