using UnityEngine;

namespace Core
{
    public class DataManager : MonoSingleton<DataManager>
    {
        public SchoolData sd;

        private void Awake()
        {
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
