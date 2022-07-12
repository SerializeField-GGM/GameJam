using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;
using Core;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] float duration = 0;
    public void GameStart(RectTransform rt)
    {
        StartCoroutine(GameStartCoroutine(rt));
    }

    private IEnumerator GameStartCoroutine(RectTransform rt)
    {
        yield return new WaitForSeconds(duration / 2);

        Sequence seq = DOTween.Sequence();

        seq.Append(rt.DOLocalMoveX(0, duration - 1f)).SetEase(Ease.InBack);
        seq.Join(rt.GetComponent<Image>().DOFade(1, duration - 0.5f)).SetEase(Ease.Linear);
        seq.AppendCallback(() => SceneManager.LoadScene("MAIN"));
    }
}
