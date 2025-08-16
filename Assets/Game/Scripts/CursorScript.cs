using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CursorScript : MonoBehaviour
{
    private GameObject overLayerTile;


    void Update()
    {
        var focusTileHit = MouseController.GetFocusOnTile();

        if (focusTileHit.HasValue)
        {
            overLayerTile = focusTileHit.Value.collider.gameObject;
            transform.position = overLayerTile.transform.position;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = overLayerTile.GetComponent<SpriteRenderer>().sortingOrder;        
        }
       
    }
    private void LateUpdate() {

        if (Input.GetMouseButtonDown(0) && overLayerTile != null)
        {
            overLayerTile.GetComponent<VisualGrid>().Show();

        }

    }
   
}
