using UnityEngine;
using static EGC.Map.MapGrid;

namespace EGC.Map
{
    public class Tile : MonoBehaviour
    {
        protected int _id;
        protected GameObject _prefab;
        public GridPosition Position;
        public bool HasDeskOn;
    }
}