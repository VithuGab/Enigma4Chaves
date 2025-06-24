using System.Linq;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private static MouseController instance;
    public LayerMask MouseLayerImpact;
    private void Awake() {
        instance = this;
    }
    void Update() {
       
        //transform.position = MouseWorldPos();      

    }
    public static Vector2 MouseWorldPos2D() {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 MousePos2D = new Vector2(MousePos.x , MousePos.y);
        return MousePos2D;
        //if (Physics.Raycast(ray , out RaycastHit rayCastHit , float.MaxValue)) { return rayCastHit.point; }
      
    }
    //Detectando mouse position por raycast Raycast
    public static RaycastHit2D? GetFocusOnTile() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D , Vector2.zero, float.MaxValue,1 << 6);
        if (hits.Length > 0)
        {
            return hits.OrderByDescending(i => i.collider.transform.position.z).First();
        }
        return null;
    }

}
