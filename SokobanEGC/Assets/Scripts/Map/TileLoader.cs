using EGC.Controllers;
using EGC.StateMachine;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;
using static EGC.Map.MapGrid;

namespace EGC.Map
{
    public class TileLoader : MonoBehaviour
    {
        [SerializeField] private TileFactory _tileFactory;
        [SerializeField] private GameObject _desksParent;
        [SerializeField] private Desk _desk;

        public GridPosition PlayerPosition { get; private set; }

        public Dictionary<GridPosition, Tile> ReadDataFromFile(string fileName, Dictionary<GridPosition, Desk> desks)
        {
            var tileDictionary = new Dictionary<GridPosition, Tile>();
            TextAsset file = Resources.Load<TextAsset>(fileName);
            if (file == null)
            {
                Debug.LogError("File not found: " + fileName);
                return tileDictionary;
            }

            string[] lines = file.text.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.None);
            string[] playerPosition = lines[0].Split();

            var player = FindObjectOfType<PlayerController>();
            PlayerPosition = new GridPosition(int.Parse(playerPosition[0]), int.Parse(playerPosition[1]));

            
            int i = 1;
            int j = 0;
            for(int y=lines.Length/2;y>-lines.Length/2;y--)
            {
                string[] numbers = lines[i].Split(' ');
               
                    for (int  x= -lines.Length/2 ; x< lines.Length/2; x++)
                    { 
                   
                        if (int.TryParse(numbers[j++], out int value))
                        {
                            if (value == 0)
                                tileDictionary.Add(new GridPosition(x, y), _tileFactory.CreateTile(TilePrefabs.TileType.Wall, new GridPosition(x, y)));
                            else if (value == 1)
                                tileDictionary.Add(new GridPosition(x, y), _tileFactory.CreateTile(TilePrefabs.TileType.Normal, new GridPosition(x, y)));
                            else if (value == 2)
                            {
                                var newTile = _tileFactory.CreateTile(TilePrefabs.TileType.FinishPoint, new GridPosition(x, y));
                                MapGrid.Instance.FinishTiles.Add(new GridPosition(x, y), newTile);
                                tileDictionary.Add(new GridPosition(x, y), newTile);
                            }
                            else if (value == 3)
                            {
                                var newTile = _tileFactory.CreateTile(TilePrefabs.TileType.Normal, new GridPosition(x, y));
                                newTile.HasDeskOn = true;
                                tileDictionary.Add(new GridPosition(x, y), newTile);
                                
                                var newDesk = Instantiate(_desk, new Vector3(x, y), Quaternion.identity, _desksParent.transform);
                                newDesk.InitialPosition = new GridPosition(x, y);    
                                desks.Add(newDesk.InitialPosition, newDesk);
                            }
                        else if (value == 4)
                        {
                            var newTile = _tileFactory.CreateTile(TilePrefabs.TileType.FinishPoint, new GridPosition(x, y));
                            newTile.HasDeskOn = true;
                            tileDictionary.Add(new GridPosition(x, y), newTile);
                            MapGrid.Instance.FinishTiles.Add(new GridPosition(x, y), newTile);

                            var newDesk = Instantiate(_desk, new Vector3(x, y), Quaternion.identity, _desksParent.transform);
                            newDesk.InitialPosition = new GridPosition(x, y);
                            desks.Add(newDesk.InitialPosition, newDesk);
                        }
                    }
                    
                    }
                j = 0;
                    
                
                i++;
                
               
            }
           

            return tileDictionary;
        }

        public void DeleteDesks()
        {
            foreach(Transform child in _desksParent.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}