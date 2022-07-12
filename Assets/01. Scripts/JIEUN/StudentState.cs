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


        void Start()
        {
        
        }

        void Update()
        {
            Escape();
            StateGage();
        }

        void StateGage() 
        {
            stressGage.value = stressVal;
            passionGage.value = passionVal;
            abilityGage.value = abilityVal;

            Mathf.Clamp(stressVal, 0, 100);
            Mathf.Clamp(passionVal, 0, 100);
            Mathf.Clamp(abilityVal, 0, 100);
        }

        public void ClickStudentB()
        {
            panel.SetActive(true);

            Sequence seq = DOTween.Sequence();

            seq.Append(panel.transform.DOScale(new Vector3(1f,1f), 0.6f));
        }

        void Escape()
        {
            
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Sequence seq = DOTween.Sequence();

                seq.Append(panel.transform.DOScale(new Vector3(1.01f,1.01f), 0.4f));
                seq.Append(panel.transform.DOScale(new Vector3(0,0),0.6f));
            }
        }
    }
}
