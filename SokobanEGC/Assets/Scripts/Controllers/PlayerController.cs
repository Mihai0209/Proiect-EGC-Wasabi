using EGC.Map;
using UnityEngine;

namespace EGC.Controllers
{
    public class PlayerController : MovementController
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite top;
        [SerializeField] private Sprite bottom;
        [SerializeField] private Sprite left;
        [SerializeField] private Sprite right;

        private void Start()
        {
            _gridData = new GridData();
            transform.position = new Vector3(MapGrid.Instance.TileLoader.PlayerPosition.X, MapGrid.Instance.TileLoader.PlayerPosition.Y);
            CurrentPosition = MapGrid.Instance.TileLoader.PlayerPosition;
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                TryMove(new Vector3(0, 1, 0));
                ChangeSprite(top);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                TryMove(new Vector3(0, -1, 0));
                ChangeSprite(bottom);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                TryMove(new Vector3(1, 0, 0));
                ChangeSprite(right);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                TryMove(new Vector3(-1, 0, 0));
                ChangeSprite(left);
            }
        }

        private void ChangeSprite(Sprite sprite)
        {
            if (_spriteRenderer != null && sprite != null)
                _spriteRenderer.sprite = sprite;
        }

    }
}