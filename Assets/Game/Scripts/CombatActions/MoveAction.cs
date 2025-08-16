using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private float speed;
    private Unit thisUnit;
    public PathObject TargetPathNode;


    public Vector3 TargetPosition;

    private void Awake() {

        transform.position = transform.position;
        TargetPosition = transform.position;
    }

    void Start() {
        thisUnit = GetComponent<Unit>();

    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //Pathfinder.Instance.FindPath(LevelGrid.Instance.GetTileObject(thisUnit.getTileTilePosition()).PathNode , TargetPathNode);
        }
    }
  
    public void MoveOnGrid(Vector3 TargetPosition) {
        //Setar aqui os bagulhos
        float stoopingDistance = 0.01f;
        if (Vector3.Distance(transform.position , TargetPosition) > stoopingDistance)
        {
            Vector3 MovDirection = (TargetPosition - transform.position).normalized;

            transform.position += MovDirection * speed * Time.deltaTime;
        }
    }
    public void SetPositionTarget(Vector3 TargetPosition) {
        this.TargetPosition = TargetPosition;

    }
}
