using System.Collections.Generic;
using UnityEngine;
using static EGC.Map.MapGrid;

namespace EGC.Map
{
    public class TileLoader : MonoBehaviour
    {
        [SerializeField] private TileFactory _tileFactory;

        public Dictionary<GridPosition, Tile> ReadDataFromFile()
        {
            var tileDictionary = new Dictionary<GridPosition, Tile>();
            if (true)
                tileDictionary.Add(new GridPosition(), _tileFactory.CreateTile(TilePrefabs.TileType.Wall));

            return tileDictionary;
        }
    }
}