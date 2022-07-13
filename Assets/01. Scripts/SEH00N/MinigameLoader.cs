using Core;
using UnityEngine;

namespace SEH00N
{
    public class MinigameLoader : MonoBehaviour
    {
        public void Load(string name)
        {
            GameManager.Instance.main.SetActive(false);
            SceneLoader.Instance.AddScene(name);
        }

        public void Remove(string name)
        {
            GameManager.Instance.main.SetActive(true);
            SceneLoader.Instance.RemoveScene(name);
        }
    }
}
