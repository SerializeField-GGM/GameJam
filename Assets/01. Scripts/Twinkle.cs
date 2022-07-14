using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;
using UI;

public class Twinkle : Buttons
{
    private Image image = null;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void DoTwinkle()
    {
        Sequence seq = DOTween.Sequence();
        
        seq.Append(image.DOFade(0, 0.1f));
        seq.Append(image.DOFade(1, 0.1f));
        seq.Append(image.DOFade(0, 0.1f));
        seq.Append(image.DOFade(1, 0.1f));
        seq.Append(image.DOFade(0, 0.1f));
        seq.Append(image.DOFade(1, 0.1f));
        Init();
    }
}
