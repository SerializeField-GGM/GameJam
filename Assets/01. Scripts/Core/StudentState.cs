using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

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

        private StudentData std = null;
        private Transform textPanel = null;
        private Slider stressS, passionS, talentS;
        private TextMeshProUGUI countT, stressT, passionT, talentT;

        private void Awake()
        {
            if (Instance == null) Instance = this;

            textPanel = transform.Find("StatVal").transform;
            stressS = transform.Find("StressGauge").GetComponentInChildren<Slider>();
            passionS = transform.Find("PassionGauge").GetComponentInChildren<Slider>();
            talentS = transform.Find("TalentGauge").GetComponentInChildren<Slider>();
            countT = textPanel.Find("CountT").GetComponent<TextMeshProUGUI>();
            stressT = textPanel.Find("StressT").GetComponent<TextMeshProUGUI>();
            passionT = textPanel.Find("PassionT").GetComponent<TextMeshProUGUI>();
            talentT = textPanel.Find("TalentT").GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            std = DataManager.Instance.std;
            countT.text = $"학생수\t\t\t\t\t\t{std.count}명";

            stressS.value = std.stress;
            stressT.text = $"스트레스\t\t\t\t\t\t\t\t\t\t\t\t{std.stress}%";

            passionS.value = std.passion;
            passionT.text = $"열정\t\t\t\t\t\t\t\t\t\t\t\t\t{std.passion}%";

            talentS.value = std.talent;
            talentT.text = $"능력\t\t\t\t\t\t\t\t\t\t\t\t\t{std.talent}%";
        }

        private void Update()
        {
            // if(Input.GetButtonDown("Jump"))
            // {
            //     Debug.Log($"123");
            //     AddStudent(1);
            // }
        }

        public void AddStress(int value)
        {
            std.stress += value;
            std.stress = Mathf.Clamp(std.stress, 0, 100);
            stressT.text = $"스트레스\t\t\t\t\t\t\t\t\t\t\t\t{std.stress}%";
            stressS.value += value;
        }
        public void AddPassion(int value)
        {
            std.passion += value;
            std.passion = Mathf.Clamp(std.passion, 0, 100);
            passionT.text = $"열정\t\t\t\t\t\t\t\t\t\t\t\t\t{std.passion}%";
            passionS.value += value;
        }
        public void AddTalent(int value)
        {
            std.talent += value;
            std.talent = Mathf.Clamp(std.talent, 0, 100);
            talentT.text = $"능력\t\t\t\t\t\t\t\t\t\t\t\t\t{std.talent}%";
            talentS.value += value;
        }

        public void AddStudent(int value)
        {
            std.count += value;
            std.talent = Mathf.Max(std.talent, 0);
            countT.text = $"학생수\t\t\t\t\t\t{std.count}명";
        }
    }
}
