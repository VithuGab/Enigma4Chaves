using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSystem 
{
    public Tilemap tilemap;
    //Reconhece se há um outro na altura desse, ai apaga e pões a altura correta
    public Dictionary<Vector2Int , TileObject> DictionaryMap;
    //   private GridObject[,] gridObjectArray;


    public GridSystem(Transform GridPrefab , Tilemap tileMap , Transform GameObjectParrent) {
        this.tilemap = tileMap;
        Tilemap CurrentTilemap = tileMap.GetComponent<Tilemap>();
        BoundsInt MBounds = CurrentTilemap.cellBounds;
        int PosX = MBounds.x;
        int PosY = MBounds.y;

        DictionaryMap = new Dictionary<Vector2Int , TileObject>();

        for (int z = MBounds.max.z; z > MBounds.min.z; z--)
        {
            for (int y = MBounds.min.y; y < MBounds.max.y; y++)
            {
                for (int x = MBounds.min.x; x < MBounds.max.x; x++)
                {
                    var tileVector3int = new Vector3Int(x , y , z);
                    var tileKey = new Vector2Int(y , x);

                    if (CurrentTilemap.HasTile(tileVector3int) && !DictionaryMap.ContainsKey(tileKey))
                    {
                        var Tile = GameObject.Instantiate(GridPrefab , GameObjectParrent);
                        var InstatieteVar = CurrentTilemap.GetCellCenterWorld(tileVector3int);



                        Tile.transform.position = new Vector3(InstatieteVar.x , InstatieteVar.y , InstatieteVar.z + 1);
                        Tile.GetComponent<SpriteRenderer>().sortingOrder = CurrentTilemap.GetComponent<TilemapRenderer>().sortingOrder + 1;
                        PosX++;
                        PosY++;
                        Debug.Log($"{PosX} + {PosY}");



                        TilePosition pos = new TilePosition(PosX , PosY);
                        TileObject tileObject = Tile.GetComponent<TileObject>();
                        //gridObjectArray[x , y] = new GridObject(this , pos);
                        tileObject.SetTilePosition(PosX , PosY);
                        tileObject.SetGridSystem(this);
                        DictionaryMap.Add(tileKey , tileObject);
                    }

                }
            }
        }
    }
}
