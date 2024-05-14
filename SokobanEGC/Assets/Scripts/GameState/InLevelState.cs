using EGC.Menu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EGC.StateMachine
{
    public class InLevelState : State
    {
        ///TODO: Add the map manager and read data from file based on the given level id


        public override void Start()
        {
            Debug.Log("In-Level State ON");
            if (GetCurrentSceneName() == "LevelScene")
                return;

            MoveToLevelScene();

            LevelInputEventManager.BackToMainMenuButtonPressed += MoveToMenuState;
        }

        public override void Finish()
        {
            Debug.Log("In-Level State OFF");

            LevelInputEventManager.BackToMainMenuButtonPressed -= MoveToMenuState;
        }

        private string GetCurrentSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }

        private void MoveToLevelScene()
        {
            SceneManager.LoadScene("LevelScene");
        }

        private void MoveToMenuState()
        {
            GameStateManager.Instance.SetState(GameStateManager.GameState.Menu);
        }
    }
}