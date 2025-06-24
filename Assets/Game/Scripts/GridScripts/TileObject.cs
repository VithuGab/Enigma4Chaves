using UnityEngine;
using UnityEngine.UI;

public class TileObject : MonoBehaviour {

    [SerializeField] private TilePosition tilePosition;   
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Text textDebug;
    
    //Quebra Galho
    private GridSystem gridSystem;
    //private GridObject gridObject;

    //private List<Unit> unitList;
    //private GridSystem<GridObject> gridSystem;

    private void Start() {
        textDebug = GetComponentInChildren<Text>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //SetTileObjectManual();
    }
    private void Update() {
        /*if (textDebug != null)
            textDebug.text = gridObject.ToString();*/

        if (Input.GetMouseButtonDown(0))
        {
            Hide();
        }
    }
    public TileObject(TilePosition tilePosition) {
        this.tilePosition = tilePosition;
    }
    public void Show() {
        spriteRenderer.color = new Color(1 , 1 , 1 , 1);
    }
    public void Hide() {
        spriteRenderer.color = new Color(1 , 1 , 1 , 0);
    }

    public void SetTilePosition(int x , int y) {
        tilePosition = new TilePosition(x , y);
    }
    public void SetGridSystem(GridSystem gridSystem) {
        this.gridSystem = gridSystem;
    }
    /*public void SetTileObject(GridObject gridObject) {
        this.gridObject = gridObject;
    }
    public void SetTileObjectManual() {
        this.gridObject = new GridObject(gridSystem , tilePosition);
    }
    public int GetZPosition() {
        return gridSystem.tilemap.cellBounds.z;
    }
    public TilePosition GetTilePosition() => tilePosition;*/

}
