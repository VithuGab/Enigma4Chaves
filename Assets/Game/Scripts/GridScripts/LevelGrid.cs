using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGrid : MonoBehaviour {
    [SerializeField] private Transform TilePrefab;
    [SerializeField] private Tilemap tileMapCombat;

    private GridSystem gridSystem;
    public static LevelGrid Instance;

    public event EventHandler OnAnyUnitMovedGridPosition;
    private void Awake() {
        if (Instance != null)
        {
            Debug.LogError("Existe outro LevelGrid! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        gridSystem = new GridSystem(TilePrefab , tileMapCombat , this.transform);
    } 

    public List<Unit> GetUnitListAtTilePosition(TilePosition gridPosition) {
        TileObject tileObject = gridSystem.GetTileObject(gridPosition);
        return tileObject.GetUnitList();
    }
    public void UnitMovedTilePosition(Unit unit , TilePosition fromPosition , TilePosition toGridPosition) {
        RemoveUnitAtTilePosition(fromPosition , unit);
        AddUnitAtTilePosition(toGridPosition , unit);
        Debug.Log($"A unidade: {unit} foi movida da posição {fromPosition} para a {toGridPosition}");
        OnAnyUnitMovedGridPosition?.Invoke(this , EventArgs.Empty);
    }
    public void RemoveUnitAtTilePosition(TilePosition gridPosition , Unit unit) {
        TileObject tileObject = gridSystem.GetTileObject(gridPosition);       
        tileObject.RemoveUnit(unit);
    }
    public void AddUnitAtTilePosition(TilePosition tilePosition , Unit unit) {
        TileObject tileObject = gridSystem.GetTileObject(tilePosition);
        tileObject.AddUnit(unit);
    }

    public GridSystem GetGridSystem() => gridSystem;
    public TileObject GetTileObjectAtTilePosition(TilePosition tilePosition) => gridSystem.GetTileObject(tilePosition);
    public Tilemap GetTilemap() => tileMapCombat;
       

}

