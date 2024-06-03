using EGC.Map;
using EGC.Menu;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EGC.StateMachine
{
    public class InLevelState : State
    {
        ///TODO: Add the map manager and read data from file based on the given level id

        private Dictionary<int, string> levels = new Dictionary<int, string>()
        {
            {0, "Level1" },
            {1, "Level2" },
            {2, "Level3" },
            {3, "Level4" },
            {4, "Level5" },
        };

        private string _levelName;
        private MenuManager _menuManager;

        public InLevelState(int levelId)
        {
            _levelName = levels[levelId];
        }

        public override void Start()
        {
            Debug.Log("In-Level State ON");
            if (GetCurrentSceneName() == "LevelScene")
                return;

            _menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
            _menuManager.HideMenu("Main Menu");
            _menuManager.HideMenu("Level Screen Menu");


            MoveToLevelScene();
            MapGrid.Instance.CreateMap(_levelName);

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