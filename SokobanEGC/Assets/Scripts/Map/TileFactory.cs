using Unity.VisualScripting;
using UnityEngine;
using static EGC.Map.MapGrid;
using static EGC.Map.TilePrefabs;

namespace EGC.Map
{
    public class TileFactory : MonoBehaviour
    {
        [SerializeField] private NormalTile _normalTile;
        [SerializeField] private WallTile _wallTile;
        [SerializeField] private FinishTile _finishTile;
        [SerializeField] private GameObject _tileContainer;
        public Tile CreateTile(TileType type,GridPosition position)
        {
            switch(type)
            {
                case TileType.Normal:
                    var normalTile = Instantiate(_normalTile, new Vector3(position.X, position.Y), Quaternion.identity, _tileContainer.transform);
                    normalTile.Position = new GridPosition(position.X, position.Y);
                    return normalTile;
                case TileType.Wall:
                    var wallTile = Instantiate(_wallTile, new Vector3(position.X, position.Y), Quaternion.identity, _tileContainer.transform);
                    wallTile.Position = new GridPosition(position.X, position.Y);
                    return wallTile;
                case TileType.FinishPoint:
                    var finishTile = Instantiate(_finishTile, new Vector3(position.X, position.Y), Quaternion.identity, _tileContainer.transform);
                    finishTile.Position = new GridPosition(position.X, position.Y);
                    return finishTile;
            }

            return null;
        }
        public TileType GetTileType(Tile tile)
        {
            if (tile is WallTile)
            {
                return TileType.Wall;
            }
            else if (tile is NormalTile)
            {
                return TileType.Normal;
            }
            else if (tile is FinishTile)
            {
                return TileType.FinishPoint;
            }
            else
            {
                return 0; 
            }
        }

      
    }
}