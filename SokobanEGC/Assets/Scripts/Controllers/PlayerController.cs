using UnityEngine;

namespace EGC.Controllers
{
    public class PlayerController : MovementController
    {
        private void HandleInput()
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                TryMove(new Vector2(0, 1));
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                TryMove(new Vector2(0, -1));
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                TryMove(new Vector2(1, 0));
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                TryMove(new Vector2(-1, 0));
            }
        }

    }
}