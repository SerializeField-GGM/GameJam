using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JUNSUNG
{
    public class Quit : MonoBehaviour
    {
        public void QuitGame()//GameManager�� �Űܾ��ҵ� 
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
