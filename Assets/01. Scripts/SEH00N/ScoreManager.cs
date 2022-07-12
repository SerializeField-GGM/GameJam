using Core;
using TMPro;
using UnityEngine;

namespace SEH00N
{
    public class ScoreManager : MonoSingleton<ScoreManager>
    {
        private int score = 0;
        private TextMeshProUGUI scoreText = null;

        private void Awake()
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        }

        public void SetScore(int value)
        {
            score += value;
            score = Mathf.Max(score, 0);
            scoreText.text = $"점수 : {score}";
        }
    }
}
