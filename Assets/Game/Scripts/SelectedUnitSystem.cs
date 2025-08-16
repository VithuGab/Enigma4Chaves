using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUnitSystem : MonoBehaviour
{
    public static SelectedUnitSystem Instance;
    public Unit selectedUnit;
    private void Awake() {
        if (Instance != null)
        {
            Debug.LogError("Existe outro SelectedUnitSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

    }
    // Update is called once per frame
    void Update() {
        //if (HandlerUnitSelection()) return;
        if (Input.GetMouseButton(0) && HandlerUnitSelection())
        {
            if (!MouseController.GetFocusOnTile().HasValue) return;

            selectedUnit.GetComponent<MoveAction>().SetPositionTarget(MouseController.GetFocusOnTile().Value.collider.transform.position);
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
