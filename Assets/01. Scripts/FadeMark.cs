using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class FadeMark : MonoBehaviour
{
    TextMeshProUGUI exclamationMark;
    [SerializeField] GameObject EatingPanel;
    [SerializeField] GameObject RoomPanel;
    void Awake()
    {
        exclamationMark = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StartCoroutine(MarkTwingkle());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator MarkTwingkle()
    {
        for(int i = 0; i < 2; i++)
        {
            exclamationMark.DOFade(0,0.20f);
            yield return new WaitForSeconds(0.20f);
            exclamationMark.DOFade(1,0.20f);
            yield return new WaitForSeconds(0.20f);
        }
        gameObject.SetActive(false);
        EatingPanel.SetActive(false);
        RoomPanel.SetActive(true);
    }
}
