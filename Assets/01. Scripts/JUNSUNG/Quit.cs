using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JUNSUNG
{
    public class Quit : MonoBehaviour
    {
        public void QuitGame()//GameManager로 옮겨야할듯 
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
