using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace JIEUN
{
    public class StudentState : MonoBehaviour
    {
        
        [SerializeField] GameObject gradePanel = null;
        [SerializeField] GameObject statePanel = null;
        [SerializeField] Slider stressGage = null;
        [SerializeField] Slider passionGage = null;
        [SerializeField] Slider abilityGage = null;

        [SerializeField] int stressVal1 = 0;
        [SerializeField] int passionVal1 = 0;
        [SerializeField] int abilityVal1 = 0;
        
        [SerializeField] int stressVal2 = 0;
        [SerializeField] int passionVal2 = 0;
        [SerializeField] int abilityVal2 = 0;

        [SerializeField] int stressVal3 = 0;
        [SerializeField] int passionVal3 = 0;
        [SerializeField] int abilityVal3 = 0;

        void Update()
        {
            StateGage();
        }
        

        public void ShowGradePanel()
        {
            gradePanel.SetActive(true);

            Sequence seq = DOTween.Sequence();

            seq.Append(gradePanel.transform.DOScale(new Vector3(1f,1f), 0.6f));
        }

        public void Click1()
        {
            statePanel.SetActive(true);
            
            Sequence seq = DOTween.Sequence();

            seq.Append(statePanel.transform.DOScale(new Vector3(1f,1f), 0.6f));

            stressGage.value = Mathf.Clamp(stressVal1, 0, 100);
            passionGage.value = Mathf.Clamp(passionVal1, 0, 100);
            abilityGage.value = Mathf.Clamp(abilityVal1, 0 ,100);
        }

        public void Click2()
        {
            statePanel.SetActive(true);
            
            Sequence seq = DOTween.Sequence();

            seq.Append(statePanel.transform.DOScale(new Vector3(1f,1f), 0.6f));

            stressGage.value = Mathf.Clamp(stressVal2, 0, 100);
            passionGage.value = Mathf.Clamp(passionVal2, 0, 100);
            abilityGage.value = Mathf.Clamp(abilityVal2, 0 ,100);
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
        
        public void Click3()
        {
            statePanel.SetActive(true);
            
            Sequence seq = DOTween.Sequence();

            seq.Append(statePanel.transform.DOScale(new Vector3(1f,1f), 0.6f));

            stressGage.value = Mathf.Clamp(stressVal3, 0, 100);
            passionGage.value = Mathf.Clamp(passionVal3, 0, 100);
            abilityGage.value = Mathf.Clamp(abilityVal3, 0 ,100);
        }
    }
}
