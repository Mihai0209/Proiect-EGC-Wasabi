using UnityEngine;
using UnityEngine.SceneManagement;

namespace EGC.StateMachine
{
    public class MenuState : State
    {
        public override void Start()
        {
            Debug.Log("Menu State ON");
            if (GetCurrentSceneName() == "MenuScene")
                return;

            MoveToMenuScene();
        }

        public override void Finish()
        {
            Debug.Log("Menu State OFF");
        }

        private string GetCurrentSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }

        private void MoveToMenuScene()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
