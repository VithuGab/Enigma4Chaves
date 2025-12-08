using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUnitSystem : MonoBehaviour
{
    public static SelectedUnitSystem Instance;
    public Unit selectedUnit;
    //temporario
    private PathObject TargetPathObject;
    private void Awake() {
        Instance = this;

    }
    // Update is called once per frame
    void Update() {
        if (HandlerUnitSelection()) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (!MouseController.GetFocusOnTile().HasValue) return;
            var tileSelected = MouseController.GetFocusOnTile().Value.collider.GetComponent<PathObject>();
            selectedUnit.GetComponent<MoveAction>().SetPositionTarget(tileSelected.transform.position);
            TargetPathObject = tileSelected;

            Debug.Log(LevelGrid.Instance.GetTileObjectAtTilePosition(selectedUnit.GetTilePosition()).pathObject + " / " + TargetPathObject);
           
            
        }
        if (Input.GetKeyDown(KeyCode.T))
        { 
            selectedUnit.GetComponent<MoveAction>().path =
                Pathfinder.Instance.FindPath(LevelGrid.Instance.GetTileObjectAtTilePosition(selectedUnit.GetTilePosition()).pathObject ,
                    TargetPathObject);
            selectedUnit.GetComponent<MoveAction>().IsBusy = true;
        }

    }
    private bool HandlerUnitSelection() {
        if (MouseController.GetFocusOnUnit() != null)
        {
            selectedUnit = MouseController.GetFocusOnUnit();
            return true;
        }
        return false;
    }
    public Unit GetUnit() => selectedUnit;

}
