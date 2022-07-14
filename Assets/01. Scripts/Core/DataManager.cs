using UnityEngine;
using System.Collections.Generic;

namespace Core
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance = null;

        public SchoolData sd;   
        public StudentData std;

        private void Awake()
        {
            //PlayerPrefs.DeleteAll();
            if(Instance == null) Instance = this;

            string sdJSON = PlayerPrefs.GetString("sdJSON", null);
            string stdJSON = PlayerPrefs.GetString("stdJSON", null);
          
            if(sdJSON.Length == 0) sd = new SchoolData() { money = 0, fame = 0, facilities = new List<string>() };
            else sd = JsonUtility.FromJson<SchoolData>(sdJSON);
            
            if(stdJSON.Length == 0) std = new StudentData() { stress = 0, talent  = 0, passion = 30, count = 70 };
            else std = JsonUtility.FromJson<StudentData>(stdJSON);
        }

        public void SaveSchoolData()
        {
            string JSON = JsonUtility.ToJson(sd);
            PlayerPrefs.SetString("sdJSON", JSON);
        }

        public void SaveStudentData()
        {
            std.passion = Mathf.Clamp(std.passion, 0 , 100);
            std.stress = Mathf.Clamp(std.stress, 0 , 100);
            std.talent = Mathf.Clamp(std.talent, 0 , 100);
            string JSON = JsonUtility.ToJson(std);
            PlayerPrefs.SetString("stdJSON", JSON);
        }

        private void OnDisable()
        {
            SaveSchoolData();
            SaveStudentData();
            //PlayerPrefs.DeleteAll();
        }
    }
}
