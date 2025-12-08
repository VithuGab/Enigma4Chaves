using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public TileObject currentTileObject;
    public TilePosition tilePosition = new TilePosition();

    public TilePosition latetilePosition = new TilePosition();
    private bool StartBool = true;

    void Update()
    {
        //Move(TargetPosition)
        if (!FeetHit()) return;
        if (StartBool) return;


        if (latetilePosition != tilePosition)
        {
            LevelGrid.Instance.UnitMovedTilePosition(this , latetilePosition , tilePosition);
            latetilePosition = tilePosition;
        }

    }
    private void LateUpdate() {
        if (!StartBool) return;
        FistFeetHit();
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
    public void FistFeetHit() {
        Collider2D hits = Physics2D.OverlapCircle(transform.position + (Vector3.up * 0.04f) , 0.05f , 1 << 6);
        if (hits == null) return;
        tilePosition = hits.gameObject.GetComponent<TileObject>().GetTilePosition();
        PathObject pathTilePosition = hits.gameObject.GetComponent<PathObject>();

        if (pathTilePosition != null)
        {
            LevelGrid.Instance.AddUnitAtTilePosition(tilePosition , this);
            latetilePosition = pathTilePosition.tilePosition;
            StartBool = false;
        }
    }
    public TilePosition CurrentTilePosition() {
        if (FeetHit()) return tilePosition;
        return new TilePosition(0 , 0);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + (Vector3.up * 0.05f) , 0.09f);

    }
    public TilePosition GetTilePosition() => tilePosition;
}
