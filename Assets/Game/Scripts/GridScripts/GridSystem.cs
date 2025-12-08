using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GridSystem 
{
    public Tilemap tilemap;
    public Dictionary<Vector2Int , TileObject> DictionaryMap;
    private TileObject[,] tileObjectArray;
    private Dictionary<TilePosition , TileObject> tileObjectDictionary;


    public GridSystem(Transform GridPrefab , Tilemap tileMap , Transform GameObjectParrent) {
        this.tilemap = tileMap;
        //Ver isso cetitnho
        var tileMaps = tilemap.transform.GetComponentsInChildren<Tilemap>().OrderByDescending(x => x.GetComponent<TilemapRenderer>().sortingOrder);
        DictionaryMap = new Dictionary<Vector2Int , TileObject>();
        tileObjectDictionary = new Dictionary<TilePosition , TileObject>();

        foreach (var tm in tileMaps)
        {
            BoundsInt bounds = tm.cellBounds;

            for (int z = bounds.max.z; z >= bounds.min.z; z--)
            {
                for (int y = bounds.min.y; y < bounds.max.y; y++)
                {
                    for (int x = bounds.min.x; x < bounds.max.x; x++)
                    {
                        //Condições para não criar o tile aqui
                        if (z == -1 /*&& ignoreBottomTiles*/)
                            return;

                        if (tm.HasTile(new Vector3Int(x , y , z)))
                        {
                            if (!DictionaryMap.ContainsKey(new Vector2Int(x , y)))
                            {
                                Vector3Int Vec3 = new Vector3Int(x , y , z);
                                Vector2Int Vec2 = new Vector2Int(x , y);
                                var overlayTile = GameObject.Instantiate(GridPrefab , GameObjectParrent);
                                var cellWorldPosition = tm.GetCellCenterWorld(Vec3);
                                overlayTile.transform.position = new Vector3(cellWorldPosition.x , cellWorldPosition.y , cellWorldPosition.z + 1);
                                overlayTile.GetComponent<SpriteRenderer>().sortingOrder = tm.GetComponent<TilemapRenderer>().sortingOrder;
                                overlayTile.gameObject.GetComponent<TileObject>().SetTilePosition(x , y , z);

                                //Tirar o "Vec2"
                                TilePosition pos = new TilePosition(Vec2.x , Vec2.y);
                                TileObject tileObject = overlayTile.GetComponent<TileObject>();
                                tileObject.SetTilePosition(Vec2.x , Vec2.y , z);
                                DictionaryMap.Add(Vec2 , tileObject);
                                tileObjectDictionary.Add(pos , tileObject);
                                Debug.Log("Foi criado o tile:  " + tileObjectDictionary[pos].ToString());

                            }
                        }
                    }
                }
            }
        }

    }
    public TileObject GetTileObject(TilePosition tile) {
        if (tileObjectDictionary.ContainsKey(tile))
        {
            return tileObjectDictionary[tile];
        }
        return null;

    }
    public TilePosition GetTilePosition(TilePosition tile) {
        if (tileObjectDictionary.ContainsKey(tile))
        {
            return tileObjectDictionary[tile].GetTilePosition();
        }
        return new TilePosition();

    }
}
