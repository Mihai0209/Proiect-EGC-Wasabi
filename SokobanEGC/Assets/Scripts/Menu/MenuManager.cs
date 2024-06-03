using EGC.StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace EGC.Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Dictionary<string, Menu> _menus = new Dictionary<string, Menu>();
        [SerializeField] private Menu _mainMenu;
        [SerializeField] private Menu _levelScreenMenu;

        private static bool isPrefabInstantiated = false;

        private void Awake()
        {
            if (!isPrefabInstantiated)
            {
                // Instantiate the prefab
                GameObject instance = this.gameObject;
                DontDestroyOnLoad(instance);

                // Mark the prefab as instantiated
                isPrefabInstantiated = true;
            }
            else
            {
                // Destroy this GameObject if the prefab is already instantiated
                Destroy(this.gameObject);
            }
            //DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _menus.Add("Main Menu", _mainMenu);
            _menus.Add("Level Screen Menu", _levelScreenMenu);

            MainMenu.PlayButtonPressed += ShowMenu;
            MainMenu.QuitButtonPressed += QuitGame;
            LevelScreenMenu.BackToMainMenuButtonPressed += ShowMenu;
            LevelScreenMenu.LevelButtonPressed += OnLevelButtonPressed;
        }

        private void OnDestroy()
        {
            MainMenu.PlayButtonPressed -= ShowMenu;
            MainMenu.QuitButtonPressed -= QuitGame;
            LevelScreenMenu.BackToMainMenuButtonPressed -= ShowMenu;
            LevelScreenMenu.LevelButtonPressed -= OnLevelButtonPressed;
        }

        public void ShowMenu(string menuName)
        {
            CloseAllMenus();
            _menus[menuName].ShowMenu();
        }

        public void HideMenu(string menuName)
        {
            _menus[menuName].HideMenu();
        }

        private void CloseAllMenus()
        {
            foreach(var menu in _menus.Values) 
            {
                menu.HideMenu();
            }
        }

        private void OnLevelButtonPressed(int levelId)
        {
            GameStateManager.Instance.LevelId = levelId;
            GameStateManager.Instance.SetState(GameStateManager.GameState.InLevel);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}
