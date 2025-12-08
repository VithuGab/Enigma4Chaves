using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private float speed;
    private Unit thisUnit;
    public PathObject TargetPathNode;

    [SerializeField] public List<PathObject> path;
    public Vector3 TargetPosition;
    public bool IsBusy = false;
    private void Awake() {

        transform.position = transform.position;
        TargetPosition = transform.position;
    }

    void Start() {
        thisUnit = GetComponent<Unit>();

    }
    private void Update() {
        GetValidActionTilePositon();
        if (Input.GetMouseButton(0) && MouseController.GetFocusOnTile().HasValue)
        {
            var tileSelected = MouseController.GetFocusOnTile().Value.collider.GetComponent<PathObject>();
            TargetPathNode = tileSelected;
        }

        if (IsBusy == true)
            MoveAlongPath();
    }
    public List<TilePosition> GetValidActionTilePositon() {
        List<TilePosition> validGridPositionList = new List<TilePosition>();

        int MaxDistance = 1;
        TilePosition unitTilePosition = SelectedUnitSystem.Instance.GetUnit().GetTilePosition();
        for (int x = -MaxDistance; x <= MaxDistance; x++)
        {
            for (int y = -MaxDistance; y <= MaxDistance; y++)
            {
                TilePosition offSetTilePosition = new TilePosition(x , y);
                TilePosition testTilePosition = unitTilePosition + offSetTilePosition;

            }
        }
        return validGridPositionList;
    }

    private void MoveAlongPath() {
        var step = 5 * Time.deltaTime;

        float zIndex = path[0].transform.position.z;
        Unit unit = thisUnit;
        unit.transform.position = Vector2.MoveTowards(unit.transform.position , path[0].transform.position , step);
        unit.transform.position = new Vector3(unit.transform.position.x , unit.transform.position.y , zIndex);

        if (Vector2.Distance(unit.transform.position , path[0].transform.position) < 0.0001f)
        {
            SetPositionTarget(path[0].transform.position);
            path.RemoveAt(0);

        }
        if (path.Count == 0)
            IsBusy = false;
    }
    public void SetPositionTarget(Vector3 TargetPosition) {
        this.TargetPosition = TargetPosition;

    }
}
