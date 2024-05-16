using EGC.Map;
using UnityEngine;
using static EGC.Map.MapGrid;

namespace EGC.Controllers
{
    public class MovementController : MonoBehaviour
    {
        protected GridData _gridData;
        protected GridPosition _initialPosition;
        protected GridPosition _currentPosition;

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
        }

        protected void TryMove(Vector2 direction)
        {
            var positionToCheck = new GridPosition(_currentPosition.X + (int)direction.x, _currentPosition.Y + (int)direction.y);

            if (CheckDestination(positionToCheck))
            {
                // Move
            }
            else
            {
                // Don't move
            }
        }

        protected bool CheckDestination(GridPosition position)
        {
            var destinationTile = _gridData.GetTile(position);
            if(TryCheckTileType(destinationTile, ref _normalTile) || TryCheckTileType(destinationTile, ref _finishTile))
            {
                if(_normalTile != null)
                {
                    if (_normalTile.HasDeskOn)
                    {

                    }
                    else
                    {
                        return true;
                    }
                }
                else if(_finishTile != null)
                {
                    if (_finishTile.HasDeskOn)
                    {

                    }
                    else
                    {
                        return true;
                    }
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
            _currentPosition = _initialPosition;
        }

        private bool TryCheckTileType<T>(Tile tile, ref T cachedNormalTile) where T : Tile
        {
            cachedNormalTile = tile as T;
            return cachedNormalTile != null;
        }
    }
}