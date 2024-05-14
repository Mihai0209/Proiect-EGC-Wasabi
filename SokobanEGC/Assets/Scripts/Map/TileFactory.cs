using UnityEngine;
using static EGC.Map.TilePrefabs;

namespace EGC.Map
{
    public class TileFactory : MonoBehaviour
    {
        public Tile CreateTile(TileType type)
        {
            switch(type)
            {
                case TileType.Normal:
                    return new NormalTile();
                case TileType.Wall:
                    return new WallTile();
                case TileType.FinishPoint:
                    return new FinishTile();
            }

            return null;
        }

        private void CalculateTransformPosBasedOnGridPos()
        {

        }
    }
}