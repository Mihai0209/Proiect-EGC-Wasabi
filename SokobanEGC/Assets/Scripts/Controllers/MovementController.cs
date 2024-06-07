using EGC.Map;
using EGC.StateMachine;
using UnityEngine;
using UnityEngine.UIElements;
using static EGC.Map.MapGrid;

namespace EGC.Controllers
{
    public class MovementController : MonoBehaviour
    {
        public GridPosition InitialPosition { get; set; }
        public GridPosition CurrentPosition;

        protected GridData _gridData;

        private Vector2 _topDirection = new Vector2(0, 1);
        private Vector2 _bottomDirection = new Vector2(0, -1);
        private Vector2 _leftDirection = new Vector2(-1, 0);
        private Vector2 _rightDirection = new Vector2(1, 0);

        private WallTile _wallTile;
        private NormalTile _normalTile;
        private FinishTile _finishTile;

        private void Start()
        {
            _gridData = new GridData();
            CurrentPosition = InitialPosition;
        }

        protected void TryMove(Vector3 direction)
        {
            var positionToCheck = new GridPosition(CurrentPosition.X + (int)direction.x, CurrentPosition.Y + (int)direction.y);

             
            if (CheckDestination(positionToCheck, direction, false))
            {
                Move(direction);
                foreach(var finishTile in MapGrid.Instance.FinishTiles.Values)
                {
                    if (!finishTile.HasDeskOn)
                        return;
                }

                GameStateManager.Instance.SetState(GameStateManager.GameState.Menu);
            }
            else
            {
                // Don't move
            }
        }

        protected bool CheckDestination(GridPosition position, Vector3 direction, bool movingDesk)
        {
            /// Playerul se urca peste o masa pe finish tile
            /// Trebuie adaugat un finish tile cu o masa pe el la nivelul 1 din initializare

            var destinationTile = _gridData.GetTile(position);
            if(TryCheckTileType(destinationTile, ref _normalTile) || TryCheckTileType(destinationTile, ref _finishTile))
            {
                if(_normalTile != null)
                {
                    return MoveToTile(_normalTile, position, direction, movingDesk);
                }
                else if(_finishTile != null)
                {
                    var canMove = MoveToTile(_finishTile, position, direction, movingDesk);
                    return canMove;
                }
            }

            if(TryCheckTileType(destinationTile, ref _wallTile))
            {
                return false;
            }
            return true;
        }

        protected void ResetPosition()
        {
            CurrentPosition = InitialPosition;
        }

        private bool TryCheckTileType<T>(Tile tile, ref T cachedNormalTile) where T : Tile
        {
            cachedNormalTile = tile as T;
            return cachedNormalTile != null;
        }

        private bool MoveToTile(Tile tile, GridPosition position, Vector3 direction, bool movingDesk)
        {
            if (movingDesk && tile.HasDeskOn)
            {
                return false;
            }

            else if (tile.HasDeskOn)
            {
                GridPosition checkNewPosition = new GridPosition(position.X + (int)direction.x, position.Y + (int)direction.y);
                if (CheckDestination(checkNewPosition, direction, true))
                {
                    CheckNextPosition(position, checkNewPosition, direction);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return true;
            }
        }

        private void CheckNextPosition(GridPosition position, GridPosition checkNewPosition, Vector3 direction)
        {
            MapGrid.Instance.Desks[position].Move(direction);
            MapGrid.Instance.GetTile(position).HasDeskOn = false;
            MapGrid.Instance.GetTile(checkNewPosition).HasDeskOn = true;

            MapGrid.Instance.Desks.Add(checkNewPosition, MapGrid.Instance.Desks[position]);
            MapGrid.Instance.Desks.Remove(position);
        }    

        public void Move(Vector3 direction)
        {
            // Move
            transform.position = transform.position + direction;
            CurrentPosition.X += (int)direction.x;
            CurrentPosition.Y += (int)direction.y;
        }
    }
}