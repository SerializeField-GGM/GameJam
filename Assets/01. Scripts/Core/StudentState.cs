using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Core
{
    public class StudentState : MonoBehaviour
    {
        #region
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

        public void ShowGradePanel()
        {
            gradePanel.SetActive(true);

            Sequence seq = DOTween.Sequence();

            seq.Append(gradePanel.transform.DOScale(new Vector3(1f, 1f), 0.6f));
        }

        public void Click1()
        {
            statePanel.SetActive(true);

            Sequence seq = DOTween.Sequence();

            seq.Append(statePanel.transform.DOScale(new Vector3(1f, 1f), 0.6f));

            stressGage.value = Mathf.Clamp(stressVal1, 0, 100);
            passionGage.value = Mathf.Clamp(passionVal1, 0, 100);
            abilityGage.value = Mathf.Clamp(abilityVal1, 0, 100);
        }

        public void Click2()
        {
            statePanel.SetActive(true);

            Sequence seq = DOTween.Sequence();

            seq.Append(statePanel.transform.DOScale(new Vector3(1f, 1f), 0.6f));

            stressGage.value = Mathf.Clamp(stressVal2, 0, 100);
            passionGage.value = Mathf.Clamp(passionVal2, 0, 100);
            abilityGage.value = Mathf.Clamp(abilityVal2, 0, 100);
        }

        public void Escape(GameObject Panel)
        {
            Sequence seq = DOTween.Sequence();

            seq.Append(Panel.transform.DOScale(new Vector3(1.05f, 1.05f), 0.3f));
            seq.Append(Panel.transform.DOScale(new Vector3(0, 0), 0.3f));
            seq.AppendCallback(() =>
            {
                Panel.SetActive(false);
            });
        }

        public void Click3()
        {
            statePanel.SetActive(true);

            Sequence seq = DOTween.Sequence();

            seq.Append(statePanel.transform.DOScale(new Vector3(1f, 1f), 0.6f));

            stressGage.value = Mathf.Clamp(stressVal3, 0, 100);
            passionGage.value = Mathf.Clamp(passionVal3, 0, 100);
            abilityGage.value = Mathf.Clamp(abilityVal3, 0, 100);
        }
        #endregion

        public static StudentState Instance = null;

        private Slider stressS = null;
        private Slider passionS = null;
        private Slider talentS = null;

        private void Awake()
        {
            if (Instance == null) Instance = this;

            stressS = transform.Find("StressGauge").GetComponentInChildren<Slider>();
            passionS = transform.Find("PassionGauge").GetComponentInChildren<Slider>();
            talentS = transform.Find("TalentGauge").GetComponentInChildren<Slider>();
        }

        private void Start()
        {
            stressS.value = DataManager.Instance.std.stress;
            passionS.value = DataManager.Instance.std.passion;
            talentS.value = DataManager.Instance.std.talent;
        }

        public void AddStress(int value)
        {
            DataManager.Instance.std.stress += value;
            stressS.value += value;
        }
        public void AddPassion(int value)
        {
            DataManager.Instance.std.passion += value;
            passionS.value += value;
        }
        public void AddTalent(int value)
        {
            DataManager.Instance.std.talent += value;
            talentS.value += value;
        }
    }
}
