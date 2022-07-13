using Core;
using UnityEngine;
using UnityEngine.UI;

namespace JIEUN
{
    public class Dust : PoolableMono
    {
        private Image image = null;

        private void Awake() {
            image = GetComponent<Image>();
        }

        public override void Reset()
        {
            image.color = new Color(0, 0, 0, 1);
        }

        public void OnCleaning(float amount)
        {
            Color c = image.color;
            c.a -= amount;
            image.color = c;

            if(image.color.a <= 0)
            {
                transform.SetParent(GameManager.Instance.pooler);
                ScoreManager.Instance.dustCount++;
                PoolManager.Instance.Push(this);
                CleanManager.Instance.i--;
            }
        }
    }
}
