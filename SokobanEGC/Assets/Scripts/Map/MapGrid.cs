using EGC.StateMachine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace EGC.Map
{
    public class MapGrid : MonoBehaviour
    {
        [SerializeField] private TileLoader _tileLoader;
        [SerializeField] private static GameObject _prefab;
        [SerializeField] private GameObject _tilesObj;

        private static MapGrid _instance;

        public static MapGrid Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<MapGrid>();
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

        public void CreateMap(string fileName)
        {
            _tiles = _tileLoader.ReadDataFromFile(fileName);
        }

        public void DeleteMap()
        {
            _tiles.Clear();

            foreach (Transform child in _tilesObj.transform)
            {
                // Destroy each child object
                Destroy(child.gameObject);
            }
        }
    }
}