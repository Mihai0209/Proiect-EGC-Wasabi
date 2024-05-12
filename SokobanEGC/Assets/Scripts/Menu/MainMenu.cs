using System;
using UnityEngine;
using UnityEngine.UI;

namespace EGC.Menu
{
    public class MainMenu : Menu
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;

        public static event Action<string> PlayButtonPressed;
        public static event Action QuitButtonPressed;

        private void Start()
        {
            _playButton.onClick.AddListener(() => PlayButtonPressed?.Invoke("Level Screen Menu"));
            _quitButton.onClick.AddListener(() => QuitButtonPressed?.Invoke());
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveAllListeners();
            _quitButton.onClick.RemoveAllListeners();
        }
    }
}
