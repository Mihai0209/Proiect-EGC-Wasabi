using EGC.StateMachine;
using UnityEngine;

namespace EGC.Menu
{
    public class ReturnToMainMenu : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GameStateManager.Instance.SetState(GameStateManager.GameState.Menu);
            }
        }
    }
}