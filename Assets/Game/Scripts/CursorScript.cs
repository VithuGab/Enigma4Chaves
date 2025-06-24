using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CursorScript : MonoBehaviour
{
    private GameObject overLayerTile;

    /*private Pathfinder pathFinder;
    private List<TileObject> path;
    public Unit unit;
    public TileObject tile;*/

    private void Start() {      
        //path = new List<TileObject>();
    }
    void Update()
    {
        var focusTileHit = MouseController.GetFocusOnTile();

        if (focusTileHit.HasValue)
        {
            overLayerTile = focusTileHit.Value.collider.gameObject;
            transform.position = overLayerTile.transform.position;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = overLayerTile.GetComponent<SpriteRenderer>().sortingOrder;        
        }
       
    }
    private void LateUpdate() {

        if (Input.GetMouseButtonDown(0))
        {
            //tile = overLayerTile.GetComponent<TileObject>();
            overLayerTile.GetComponent<TileObject>().Show();
            //path = pathFinder.FindPath(unit.currentTileObject , tile);

            //tile.gameObject.GetComponent<TileObject>().Hide();
        }
       /* if (path.Count > 0)
        {
            MoveAlongPath();
        }*/
    }
    /*private void MoveAlongPath() {
        var step = 5 * Time.deltaTime;

        float zIndex = path[0].transform.position.z;
        unit.transform.position = Vector2.MoveTowards(unit.transform.position , path[0].transform.position , step);
        unit.transform.position = new Vector3(unit.transform.position.x , unit.transform.position.y , zIndex);
        if (Vector2.Distance(unit.transform.position , path[0].transform.position) < 0.00001f)
        {
           
            path.RemoveAt(0);
        }
    }*/

}
