using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour {

    [SerializeField] private TilePosition tilePosition;    

    private List<Unit> unitList;
    private int ZPosition;
    private void Awake() {
        unitList = new List<Unit>();
    }
    private void Start() {
        
    }
    #region Unit Manager
    public void AddUnit(Unit unit) {
       if (unit == null) 
            unitList = new List<Unit>();
        unitList.Add(unit);
    }
    public void RemoveUnit(Unit unit) {
        if (unit == null)
            unitList = new List<Unit>();
        unitList.Remove(unit);
    }
    public bool HasEnyUnit() {
        return unitList.Count > 0;
    }

    public Unit GetUnit() {
        //Pega a primeira Unidade
        if (HasEnyUnit())
        {
            return unitList[0];
        }
        return null;
    }
    #endregion
    public void SetTilePosition(int x , int y,int z) {
        tilePosition = new TilePosition(x , y);
        this.ZPosition = z;
    }
    public List<Unit> GetUnitList() => unitList;
    public int GetZPosition() => ZPosition;
    public TilePosition GetTilePosition() => tilePosition;
    public override string ToString() {
        return tilePosition.ToString();
    }
    /*public void SetTileObject(GridObject gridObject) {
        this.gridObject = gridObject;
    }
    public void SetTileObjectManual() {
        this.gridObject = new GridObject(gridSystem , tilePosition);
    }
    public int GetZPosition() {
        return gridSystem.tilemap.cellBounds.z;
    }
    public TilePosition GetTilePosition() => tilePosition;*/

}
