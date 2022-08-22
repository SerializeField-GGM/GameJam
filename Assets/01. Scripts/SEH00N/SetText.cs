using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SEH00N
{
    public class SetText : MonoBehaviour
    {
        [SerializeField] List<string> texts = new List<string>();
        private TextMeshProUGUI tmp = null;
        private TMP_InputField inputField;
        private bool isCorrect = false;
        private int randIndex;

        private void Awake()
        {
            tmp = GetComponent<TextMeshProUGUI>();
            inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        }

        private void Start()
        {
            randIndex = Random.Range(0, texts.Count);
            tmp.text = $"제시어: {texts[randIndex]}";
            inputField.ActivateInputField();
            //StartCoroutine(MakeText());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return) && inputField.interactable)
            {
                if (texts[randIndex] == inputField.text)
                {
                    isCorrect = true;
                    ScoreManager.Instance.SetScore(100);
                    ResetText();
                }
                else
                {
                    ScoreManager.Instance.SetScore(-25);
                    ResetText();
                }
            }
        }

        public void EnterText()
        {
            if(inputField.interactable)
            {
                if (texts[randIndex] == inputField.text)
                {
                    isCorrect = true;
                    ScoreManager.Instance.SetScore(100);
                    ResetText();
                }
                else
                {
                    ScoreManager.Instance.SetScore(-25);
                    ResetText();
                }
            }
        }

        private void ResetText()
        {
            inputField.text = null;
            inputField.ActivateInputField();
            randIndex = Random.Range(0, texts.Count);
            tmp.text = $"제시어: {texts[randIndex]}";
        }

        private IEnumerator MakeText()
        {
            while (true)
            {
                randIndex = Random.Range(0, texts.Count);
                tmp.text = $"제시어: {texts[randIndex]}";

                yield return new WaitUntil(() => isCorrect);
                isCorrect = false;
            }
        }
    }
}
