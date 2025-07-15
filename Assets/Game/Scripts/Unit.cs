using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int Speed;
    public Vector3 TargetPosition;



    public TileObject currentTileObject;
    public PathObject currentTilePath;
    public TilePosition tilePosition;
    private void Awake() {
        transform.position = transform.position;
        TargetPosition = transform.position;
        
    }
    void Update()
    {
        //Move(TargetPosition)
        if (!FeetHit()) return;
        Debug.Log(tilePosition.ToString());
        if (!LevelGrid.Instance.GetTileObjectAtTilePosition(tilePosition).HasEnyUnit())
        {
            LevelGrid.Instance.AddUnitAtTilePosition(currentTileObject.GetTilePosition() , this);
        }

        //Mudando de tile
        /*TilePosition newTilePosition = LevelGrid.Instance.GetTilePosition( tilePosition );
        if (newTilePosition != tilePosition)
        {
            //Mudou de Tile
            LevelGrid.Instance.UnitMovedTilePosition(this , tilePosition , CurrentTilePosition());
            Debug.Log("Mudou de tile");
        }*/

    }
    public void Move(Vector3 TargetPosition) {
        //Setar aqui os bagulhos
        float stoopingDistance = 0.01f;
        if (Vector3.Distance(transform.position , TargetPosition) > stoopingDistance)
        {
            Vector3 MovDirection = (TargetPosition - transform.position).normalized;

            transform.position += MovDirection * Speed * Time.deltaTime;
        }
    }
    private TilePosition CurrentTilePosition() {
        if (FeetHit()) return tilePosition;
        return new TilePosition(0 , 0);
    }

    public void SetPositionTarget(Vector3 TargetPosition) {
        this.TargetPosition = TargetPosition;

    }
    //Pegar mais de um para não bugar
    private bool FeetHit() {
        Collider2D hits = Physics2D.OverlapCircle(transform.position + (Vector3.up * 0.05f) , 0.04f , 1 << 6);
        if (hits == null) return false;
        TileObject hitTile = hits.gameObject.GetComponent<TileObject>();

        PathObject pathTilePosition = hits.gameObject.GetComponent<PathObject>();

        if (pathTilePosition != null)
        {
            //tilePosition = pathTilePosition.tilePosition;
            tilePosition = hitTile.GetComponent<TileObject>().GetTilePosition(); ;
            currentTileObject = pathTilePosition.getLinkedTileObject();
            return true;
        }
        return false;

    }
    public PathObject GetPathNode() {
        return currentTilePath;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + (Vector3.up * 0.05f) , 0.09f);

    }
}
