using EGC.Map;
using UnityEngine;
using static EGC.Map.MapGrid;

namespace EGC.Controllers
{
    public class GridData
    {
        public Tile GetTile(GridPosition position)
        {
            return MapGrid.Instance.GetTile(position);
        }
    }
}
