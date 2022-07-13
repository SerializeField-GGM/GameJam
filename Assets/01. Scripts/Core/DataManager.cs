using UnityEngine;

namespace Core
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance = null;

        public SchoolData sd;

        private void Awake()
        {
            if(Instance == null) Instance = this;

            string sdJSON = PlayerPrefs.GetString("sdJSON", null);
            
            if(sdJSON == null) sd = new SchoolData() { money = 0, fame = 0 };
            else sd = JsonUtility.FromJson<SchoolData>(sdJSON);
        }

        public void SaveSchoolData()
        {
            string JSON = JsonUtility.ToJson(sd);
            PlayerPrefs.SetString("sdJSON", JSON);
        }

        private void OnDisable()
        {
            SaveSchoolData();
        }
    }
}
