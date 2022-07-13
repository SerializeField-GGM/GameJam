using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EatingText : MonoBehaviour
{
    Text eatText;
    private void Awake()
    {
        eatText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        eatText.text = "먹는중";
        StartCoroutine(ShowText());
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
