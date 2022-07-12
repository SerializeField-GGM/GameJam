using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace JIEUN
{
    public class StudentState : MonoBehaviour
    {
        
        [SerializeField] GameObject panel = null;
        [SerializeField] Slider stressGage = null;
        [SerializeField] Slider passionGage = null;
        [SerializeField] Slider abilityGage = null;

        [SerializeField] int stressVal = 0;
        [SerializeField] int passionVal = 0;
        [SerializeField] int abilityVal = 0;

        void Update()
        {
            StateGage();
        }

        void StateGage() 
        {
            stressGage.value = stressVal;
            passionGage.value = passionVal;
            abilityGage.value = abilityVal;

            stressVal = Mathf.Clamp(stressVal, 0, 100);
            passionVal = Mathf.Clamp(passionVal, 0, 100);
            abilityVal = Mathf.Clamp(abilityVal, 0, 100);
        }

        public void ClickStudentB()
        {
            panel.SetActive(true);

            Sequence seq = DOTween.Sequence();

            seq.Append(panel.transform.DOScale(new Vector3(1f,1f), 0.6f));
        }

        public void Escape()
        {
            Sequence seq = DOTween.Sequence();

            seq.Append(panel.transform.DOScale(new Vector3(1.05f, 1.05f), 0.3f));
            seq.Append(panel.transform.DOScale(new Vector3(0, 0), 0.3f));
            seq.AppendCallback(() =>
            {
                panel.SetActive(false);
            });
        }
    }
}
