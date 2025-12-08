using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CursorScript : MonoBehaviour
{
    public static CursorScript Instance;
    [SerializeField]private PathObject overLayerTile;

    public Unit unit;
    private void Awake() {

        if (Instance != null)
        {
            Debug.LogError("Existe outro CursorScript! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

    }
    void Update()
    {
        var focusTileHit = MouseController.GetFocusOnTile();

        if (focusTileHit.HasValue)
        {
            focusTileHit.Value.collider.gameObject.TryGetComponent<PathObject>(out PathObject tileObjectHit);
            overLayerTile = tileObjectHit;
            if (overLayerTile == null) return;
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
