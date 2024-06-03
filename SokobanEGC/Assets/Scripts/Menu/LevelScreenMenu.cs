using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EGC.Menu
{
    public class LevelScreenMenu : Menu
    {
        [SerializeField] private Button _backToMainMenuButton;
        [SerializeField] private List<Button> _levelButtons;

        public static event Action<int> LevelButtonPressed;
        public static event Action<string> BackToMainMenuButtonPressed;

        private void Start()
        {
            _backToMainMenuButton.onClick.AddListener(() => BackToMainMenuButtonPressed?.Invoke("Main Menu"));
            
            for(int i = 0; i <  _levelButtons.Count; i++)
            {
                var index = i;
                _levelButtons[i].onClick.AddListener(() => LevelButtonPressed?.Invoke(index));
            }
        }

        private void OnDestroy()
        {
            _backToMainMenuButton.onClick.RemoveAllListeners();

            for (int i = 0; i < _levelButtons.Count; i++)
            {
                _levelButtons[i].onClick.RemoveAllListeners();
            }
        }
    }
}