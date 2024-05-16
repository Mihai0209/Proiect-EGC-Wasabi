using EGC.StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace EGC.Map
{
    public class MapGrid : MonoBehaviour
    {
        [SerializeField] private TileLoader _tileLoader;

        private static MapGrid _instance;

        public static MapGrid Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<MapGrid>();

                    if (_instance == null)
                    {
                        var mapGrid = new GameObject(typeof(MapGrid).Name);
                        _instance = mapGrid.AddComponent<MapGrid>();
                    }
                }

                return _instance;
            }
        }

        private Dictionary<GridPosition, Tile> _tiles = new Dictionary<GridPosition, Tile>();

        public struct GridPosition
        {
            public GridPosition(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X, Y;
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {

                Destroy(gameObject);
                return;
            }
        }


        public Tile GetTile(GridPosition position)
        {
            return new Tile(); //placeholder
        }

        private void CreateMap()
        {
            _tiles = _tileLoader.ReadDataFromFile();
        }

        private void DeleteMap()
        {

        }
    }
}