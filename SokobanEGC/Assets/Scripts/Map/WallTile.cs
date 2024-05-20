using UnityEngine;
using static EGC.Map.MapGrid;

namespace EGC.Map
{
    public class WallTile : Tile
    {
        private int _id;
        private GridPosition _position;
        private GameObject _prefab;

        public bool HasDeskOn { get; set; }
    }
}