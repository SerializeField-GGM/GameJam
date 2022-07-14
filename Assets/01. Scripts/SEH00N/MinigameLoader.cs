using Core;
using UnityEngine;
using UI;

namespace SEH00N
{
    public class MinigameLoader : Buttons
    {
        public void Load(string name)
        {
            Time.timeScale = 1;
            GameManager.Instance.main.SetActive(false);
            SceneLoader.Instance.AddScene(name);
            Init();
        }

        public void Remove(string name)
        {
            Time.timeScale = 1;
            GameManager.Instance.main.SetActive(true);
            SceneLoader.Instance.RemoveScene(name);
            Init();
        }
    }
}
