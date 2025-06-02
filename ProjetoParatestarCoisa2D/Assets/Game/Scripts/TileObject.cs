using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    //private GridSystem<GridObject> gridSystem;
    private TilePosition tilePosition;
    //private List<Unit> unitList;

    public TileObject(TilePosition tilePosition) {
        this.tilePosition = tilePosition;
    }
}
