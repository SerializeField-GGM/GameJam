using UnityEngine.SceneManagement;
using UnityEngine;

namespace Core
{
    public class SceneLoader
    {
        public static SceneLoader Instance = null;

        public void AddScene(string name)
        {
            SceneManager.LoadScene(name, LoadSceneMode.Additive);
        }

        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name, LoadSceneMode.Single);
        }

        public void RemoveScene(string name)
        {
            SceneManager.UnloadSceneAsync(name);
        }
    }
}
