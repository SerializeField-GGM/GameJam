using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] RectTransform left, right, fadeImage;
    private RectTransform rt;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
        GameStart();
    }

    public void GameStart()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(fadeImage.DOLocalMoveX(1920, duration - 0.5f)).SetEase(Ease.InBack);
        seq.Join(fadeImage.GetComponent<Image>().DOFade(1, duration)).SetEase(Ease.Linear);

        // seq.Append(right.DOLocalMoveX(1440, duration - 1f)).SetEase(Ease.InBack);
        // seq.Join(left.DOLocalMoveX(-1440, duration - 1f)).SetEase(Ease.InBack);
        // seq.Join(right.GetComponent<Image>().DOFade(0, duration - 0.5f)).SetEase(Ease.Linear);
        // seq.Join(left.GetComponent<Image>().DOFade(0, duration - 0.5f)).SetEase(Ease.Linear);

        // seq.Append(right.DOLocalMoveY(-810, duration - 1f)).SetEase(Ease.InBack);
        // seq.Join(left.DOLocalMoveY(810, duration - 1f)).SetEase(Ease.InBack);
        // seq.Join(right.GetComponent<Image>().DOFade(0, duration - 0.5f)).SetEase(Ease.Linear);
        // seq.Join(left.GetComponent<Image>().DOFade(0, duration - 0.5f)).SetEase(Ease.Linear);
    }
}
