using EGC.Map;
using EGC.Menu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EGC.StateMachine
{
    public class MenuState : State
    {
        private MenuManager _menuManager;

        public override void Start()
        {
            Debug.Log("Menu State ON");
            if (GetCurrentSceneName() == "MenuScene")
                return;

            MoveToMenuScene();
            _menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
            _menuManager.HideMenu("Main Menu");
            _menuManager.ShowMenu("Level Screen Menu");
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
            MapGrid.Instance.DeleteMap();
            SceneManager.LoadScene("MenuScene");
        }
    }
}
