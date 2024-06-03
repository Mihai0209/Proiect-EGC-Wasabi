using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static EGC.Map.MapGrid;

namespace EGC.Map
{
    public class TileLoader : MonoBehaviour
    {
        [SerializeField] private TileFactory _tileFactory;

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

            int i = 0;
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