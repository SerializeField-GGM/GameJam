using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JUNSUNG;

public class EatingText : MonoBehaviour
{
    Text eatText;
    [SerializeField] AudioClip hululukJJapJJap;
    private void Awake()
    {
        eatText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        eatText.text = "먹는중";
        StartCoroutine(ShowText());
        BGMControll.Instance.PlayButtonSound(hululukJJapJJap);
    }

    IEnumerator ShowText()
    {
        while(true)
        { 
            eatText.DOText("먹는중...", 2f);
            yield return new WaitForSeconds(2f);
            eatText.text = "먹는중";
        }
    }
}
