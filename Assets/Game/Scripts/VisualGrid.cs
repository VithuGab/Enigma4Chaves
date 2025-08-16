using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualGrid : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private TileObject thisTileObject;
    void Start()
    {
        LevelGrid.Instance.OnAnyUnitMovedGridPosition += LevelGrid_OnAnyUnitMovedGridPosition;
        spriteRenderer = GetComponent<SpriteRenderer>();
        thisTileObject = GetComponent<TileObject>();
        Hide();
    }

    private void LevelGrid_OnAnyUnitMovedGridPosition(object sender , EventArgs e) {
        if (thisTileObject.GetUnitList().Count > 0)
        {
            Show();
        }
        if (thisTileObject.GetUnitList().Count == 0)
        {
            Hide();
        }
    }

    private void Update() {
        if (thisTileObject.GetUnitList().Count > 0)
        {
            Show();
        }else if (Input.GetMouseButtonDown(0))
        {
            Hide();
        }
        
    }

    public void Show() {
        spriteRenderer.enabled = true;
    }
    public void Hide() {
        spriteRenderer.enabled = false;
    }
}
