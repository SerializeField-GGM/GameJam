using System.Collections;
using UnityEngine;

namespace UI
{
    public class Quit : MonoBehaviour
    {
        public void DoQuit()
        {
            StartCoroutine(DoQuitCorountine());
        }

        private IEnumerator DoQuitCorountine()
        {
            yield return new WaitForSeconds(0.6f);
            Application.Quit();
        }
    }
}
