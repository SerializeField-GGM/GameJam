using UnityEngine;

namespace Core
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance = null;

        public SchoolData sd;
        public StudentData std;

        private void Awake()
        {
            if(Instance == null) Instance = this;

            string sdJSON = PlayerPrefs.GetString("sdJSON", null);
            string stdJSON = PlayerPrefs.GetString("stdJSON", null);
            
            if(sdJSON == null) sd = new SchoolData() { money = 0, fame = 0 };
            else sd = JsonUtility.FromJson<SchoolData>(sdJSON);
            
            if(stdJSON == null) std = new StudentData() { stress = 0, talent  = 0, passion = 0, count = 0 };
            else std = JsonUtility.FromJson<StudentData>(stdJSON);
        }

        public void SaveSchoolData()
        {
            string JSON = JsonUtility.ToJson(sd);
            PlayerPrefs.SetString("sdJSON", JSON);
        }

        public void SaveStudentData()
        {
            string JSON = JsonUtility.ToJson(std);
            PlayerPrefs.SetString("stdJSON", JSON);
        }

        private void OnDisable()
        {
            SaveSchoolData();
            SaveStudentData();
        }
    }
}
