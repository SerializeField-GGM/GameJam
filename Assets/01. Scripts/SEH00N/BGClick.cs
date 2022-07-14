using Core;
using UnityEngine;
using JUNSUNG;

namespace SEH00N
{
    public class BGClick : MonoBehaviour
    {
        [SerializeField] float stressDeAm, stressInAm, talentInAm, passionInAm, passionDeAm, moneyInAm, delay;
        [SerializeField] Transform trm;
        private StudentData std = null;
        private SchoolData sd = null;
        private float a = 0;

        [SerializeField] AudioClip bgGlickSound;
        private void Start()
        {
            std = DataManager.Instance.std;
            sd = DataManager.Instance.sd;
        }

        private void Update()
        {
            a += Time.deltaTime;
        }

        public void PlayGround()
        {
            if(a < delay) return;

            if(std.stress <= 0)
            {
                TextSpawn.Instance.SpawnText("소모할 스트레스가 부족합니다!!", trm.position);
                return;
            }
            TextSpawn.Instance.SpawnText($"스트레스 {stressDeAm}!!", trm.position);
            StudentState.Instance.AddStress(stressDeAm);
            SoundControll.Instance.PlayButtonSound(bgGlickSound);
            a = 0;
        }

        public void Laboratory()
        {
            if(a < delay) return;

            StudentState.Instance.AddStress(stressInAm);
            StudentState.Instance.AddTalent(talentInAm);

            TextSpawn.Instance.SpawnText($"스트레스 +{stressInAm}!!\n능력 +{talentInAm}!!", trm.position);
            SoundControll.Instance.PlayButtonSound(bgGlickSound);
            a = 0;
        }

        public void StudyRoom()
        {
            if(a < delay) return;

            StudentState.Instance.AddStress(stressInAm);
            StudentState.Instance.AddPassion(passionInAm);

            TextSpawn.Instance.SpawnText($"스트레스 +{stressInAm}!!\n열정 +{passionInAm}!!", trm.position);
            SoundControll.Instance.PlayButtonSound(bgGlickSound);
            a = 0;
        }

        public void PartTimeJob()
        {
            if(a < delay) return;

            if(std.passion <= 0)
            {
                TextSpawn.Instance.SpawnText("소모할 열정이 부족합니다!!", trm.position);
                return;
            }

            StudentState.Instance.AddPassion(passionDeAm);
            MoneyManager.Instance.SetMoney((long)moneyInAm);

            TextSpawn.Instance.SpawnText($"열정 {passionDeAm}!!\n돈 +{moneyInAm}!!", trm.position);
            SoundControll.Instance.PlayButtonSound(bgGlickSound);
             a = 0;
        }
    }
}
