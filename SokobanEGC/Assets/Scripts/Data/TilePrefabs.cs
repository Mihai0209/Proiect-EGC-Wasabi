using System.Collections.Generic;
using UnityEngine;

namespace EGC.Map
{
    [CreateAssetMenu(fileName = "Map", menuName = "Map/Tile")]
    public class TilePrefabs : ScriptableObject
    {
        public enum TileType
        {
            Normal,
            Wall,
            FinishPoint
        }

        public List<TileType> _tileTypes;
        public List<Tile> _tiles;
    }
}
