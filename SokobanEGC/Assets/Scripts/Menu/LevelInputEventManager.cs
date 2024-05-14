using System;
using UnityEngine;

namespace EGC.Menu
{
    public class LevelInputEventManager : MonoBehaviour
    {
        public static event Action BackToMainMenuButtonPressed;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                BackToMainMenuButtonPressed?.Invoke();
            }
        }
    }
}