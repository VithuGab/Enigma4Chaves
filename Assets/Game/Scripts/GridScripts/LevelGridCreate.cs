using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGridCreate : MonoBehaviour {
    [SerializeField] private Transform debugPrefab;
    [SerializeField] private Tilemap tileMap;
    private GridSystem gridSystem;

    //private GridSystem<GridObject> gridSystem;
    public static LevelGridCreate Instance;

    //public event EventHandler OnAnyUnitMovedGridPosition;
    private void Awake() {
        if (Instance != null)
        {
            Debug.LogError("Existe outro LevelGridCreate! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start() {
        //gridSystem.CreateGridSystem(debugPrefab, transform);
        //gridSystem = new GridSystem(debugPrefab, tileMap , this.transform,.5f);
        gridSystem = new GridSystem(debugPrefab , tileMap , this.transform);

        //Ve se encaixa
        //Pathfinding.Instance.Setup(width , height , sizeScale);
    }
    public GridSystem GetGridSystem() => gridSystem;



    /*
    public void AddUnitAtGridPosition(GridPosition gridPosition , Unit unit) {
        GridObject gridObject = gridSystem.GetGridObjects(gridPosition);
        gridObject.AddUnit(unit);
    }
    public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition) {
        GridObject gridObject = gridSystem.GetGridObjects(gridPosition);
        return gridObject.GetUnitList();
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition , Unit unit) {
        GridObject gridObject = gridSystem.GetGridObjects(gridPosition);
        gridObject.RemoveUnit(unit);
    }
    public void UnitMovedGridPosition(Unit unit , GridPosition fromPosition , GridPosition toGridPosition) {
        RemoveUnitAtGridPosition(fromPosition , unit);
        AddUnitAtGridPosition(toGridPosition , unit);
        OnAnyUnitMovedGridPosition?.Invoke(this , EventArgs.Empty);
    }
    //Verifica se h� unidades na gridPosition
    public bool HasEnyUnitOnGridPosition(GridPosition gridPosition) {
        //GridObject gridObject = gridSystem.GetGridPosition(gridPosition);
        GridObject gridObject = gridSystem.GetGridObjects(gridPosition);
        return gridObject.HasEnyUnit();
    }
    //Faz a mesma coisa mas s� com uma unidade
    public Unit GetUnitAtGridPosition(GridPosition gridPosition) {
        //GridObject gridObject = gridSystem.GetGridPosition(gridPosition);
        GridObject gridObject = gridSystem.GetGridObjects(gridPosition);
        return gridObject.GetUnit();
    }
    public IInteractable GetInteractableObjectAtGridPosition(GridPosition gridPosition) {
        GridObject gridObject = gridSystem.GetGridObjects(gridPosition);
        return gridObject.GetInteractableObject();
    }
    public void SetInteractableObjectAtGridPosition(GridPosition gridPosition , IInteractable interactableObject) {
        GridObject gridObject = gridSystem.GetGridObjects(gridPosition);
        gridObject.SetInteractebleObject(interactableObject);
    }
    public void SetObjectAtGridPosition(GridPosition gridPosition , GameObject GO) {

        GridObject gridObject = gridSystem.GetGridObjects(gridPosition);
        if (HasEnyUnitOnGridPosition(gridPosition)) Debug.Log("Pegou um Kit M�dico");

        //gridObject.SetInteractebleObject(interactableObject);
    }
    public GridPosition GetGridPosition(Vector3 WorldPosition) => gridSystem.GetGridPosition(WorldPosition);
    //Converte gridPosition Para Vector 3 para a gente ter a posi��o real da unidade
    public Vector3 GetWoldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);
    public bool IsValidGridPosition(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition);

    public int GetHeigth() => gridSystem.getHeight();
    public int GetWidth() => gridSystem.getWidth();
    */

}

