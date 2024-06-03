using EGC.Controllers;
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

        public GridPosition PlayerPosition { get; private set; }

        public Dictionary<GridPosition, Tile> ReadDataFromFile(string fileName)
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
                                tileDictionary.Add(new GridPosition(x, y), _tileFactory.CreateTile(TilePrefabs.TileType.FinishPoint, new GridPosition(x, y)));
                            else if (value == 3)
                                tileDictionary.Add(new GridPosition(x, y), _tileFactory.CreateTile(TilePrefabs.TileType.Normal, new GridPosition(x, y)));
                        }
                    
                    }
                j = 0;
                    
                
                i++;
                
               
            }
           

            return tileDictionary;
        }
    }
}