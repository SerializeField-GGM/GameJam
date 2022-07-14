using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JUNE
{
    public class RamenBroom : MonoBehaviour
    {
        private void OnEnable()
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
