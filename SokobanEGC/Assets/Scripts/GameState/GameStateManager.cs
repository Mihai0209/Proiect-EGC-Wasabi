using UnityEngine;

namespace EGC.StateMachine
{
    public class GameStateManager : MonoBehaviour
    {
        public enum GameState
        {
            Menu,
            InLevel,
            LevelWon
        }

        private static GameStateManager _instance;

        public static GameStateManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = FindObjectOfType<GameStateManager>();
                
                    if(_instance == null ) 
                    {
                        var gameStateManager = new GameObject(typeof(GameStateManager).Name);
                        _instance = gameStateManager.AddComponent<GameStateManager>();
                    }
                }

                return _instance;
            }
        }

        public State CurrentState
        {
            get;
            private set;
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {

                Destroy(gameObject);
                return;
            }

            SetState(GameState.Menu);
        }

        public void SetState(GameState gameState)
        {
            if(CurrentState != null)
                CurrentState.Finish();

            switch(gameState)
            {
                case GameState.Menu:
                    CurrentState = new MenuState();
                    break;

                case GameState.InLevel:
                    CurrentState = new InLevelState();
                    break;
            }

            CurrentState.Start();
        }
    }
}

