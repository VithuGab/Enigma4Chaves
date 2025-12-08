using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// !!!!! AINDA NÃO ESTÁ REVISADO!!!!!!!!!!!!!!!!!!!!!
public class PathObject : MonoBehaviour {
    private int G, H;
    private int F { get { return G + H; } }
    private int Index;
    public bool isBlocked;
    private PathObject previus;



    //Heranças do tile
    private TileObject currentLinkedTile;
    public TilePosition tilePosition;
    private int ZPosition;
    private int tileLayer;

    private void Awake() {
        currentLinkedTile = GetComponent<TileObject>();
    }
    private void Start() {
        tilePosition = currentLinkedTile.GetTilePosition();
        tileLayer = currentLinkedTile.GetZPosition();
        ZPosition = currentLinkedTile.GetZPosition();
    }

    public void SetGCost(int gCost) {
        this.G = gCost;
    }
    public void SetHCost(int hCost) {
        this.H = hCost;
    }
    public void SetIndexPath(int index) {
        this.Index = index;
    }
    public void SetPreviusPathNode(PathObject pathNode) {
        previus = pathNode;
    }
    public void SetIsWalkable(bool isWakable) {
        this.isBlocked = isWakable;
    }
    public void ResetCameFromPathNode() {
        previus = null;
    }

    public int GetGCost() => G;
    public int GetHCost() => H;
    public int GetFCost() => F;
    public TileObject getLinkedTileObject() => currentLinkedTile;
    public PathObject GetPreviusPathObject() {
        return previus;
    }

    public TilePosition GetTilePosition() => tilePosition;
    public bool GetIsNotWalkable() => isBlocked;
    public float GetZPosition() => ZPosition;
    public int GetTileLayer() => tileLayer;
    

    //TUDO: Criar uma gizmo para saber qual tile esta blokeado


}

