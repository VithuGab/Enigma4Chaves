using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class Pathfinder : MonoBehaviour {

    public static Pathfinder Instance;
    private void Awake() {
        if (Instance != null)
        {
            Debug.LogError("Existe outro Pathfinder! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public List<PathObject> FindPath(PathObject start , PathObject end) {

        List<PathObject> openList = new List<PathObject>();
        List<PathObject> closedList = new List<PathObject>();                   

        openList.Add(start);

        while (openList.Count > 0)
        {

            PathObject currentPathNode = openList.OrderBy(x => x.GetFCost()).First();

            openList.Remove(currentPathNode);
            closedList.Add(currentPathNode);

            ;
            if (currentPathNode == end)
            {
                return GetFinishedList(start , end);
            }

            Debug.Log(GetNeighbourTiles(currentPathNode).Count);
            foreach (var neighbour in GetNeighbourTiles(currentPathNode))
            {
                Debug.Log("Chegou aqui");
                //Isso verifica a distancia de um "Pulo" : 1
                if (neighbour.isBlocked || closedList.Contains(neighbour) || Mathf.Abs(currentPathNode.GetZPosition() - neighbour.GetZPosition()) > 1)
                {
                    continue;
                }

                neighbour.SetGCost(GetManhattenDistance(start , neighbour));
                neighbour.SetHCost(GetManhattenDistance(end , neighbour));

                neighbour.SetPreviusPathNode(currentPathNode);

                if (!openList.Contains(neighbour))
                {
                    openList.Add(neighbour);
                }
            }
        }

        return new List<PathObject>();
    }
    private List<PathObject> GetFinishedList(PathObject start , PathObject end) {
        List<PathObject> finishedList = new List<PathObject>();
        PathObject currentTile = end;

        while (currentTile != start)
        {
            finishedList.Add(currentTile);
            currentTile = currentTile.GetPreviusPathObject();

        }
        finishedList.Reverse();
        return finishedList;
    }
    private int GetManhattenDistance(PathObject start , PathObject neighbour) {
        return Mathf.Abs(start.GetTilePosition().x - neighbour.GetTilePosition().x) +
            Mathf.Abs(start.GetTilePosition().y - neighbour.GetTilePosition().y);
    }

    private List<PathObject> GetNeighbourTiles(PathObject currentPathNode) {
        var gridmap = LevelGrid.Instance.GetGridSystem().DictionaryMap;

        List<PathObject> neighbours = new List<PathObject>();

        //top
        Vector2Int locationToCheck = new Vector2Int(
            currentPathNode.GetTilePosition().x ,
            currentPathNode.GetTilePosition().y + 1
        );
        if (gridmap.ContainsKey(locationToCheck))
        {
            neighbours.Add(gridmap[locationToCheck].GetComponent<PathObject>());
        }

        //Buttom
        locationToCheck = new Vector2Int(
            currentPathNode.GetTilePosition().x ,
            currentPathNode.GetTilePosition().y - 1
        );
        if (gridmap.ContainsKey(locationToCheck))
        {
            neighbours.Add(gridmap[locationToCheck].GetComponent<PathObject>());
        }

        //right
        locationToCheck = new Vector2Int(
            currentPathNode.GetTilePosition().x + 1 ,
            currentPathNode.GetTilePosition().y
        );
        if (gridmap.ContainsKey(locationToCheck))
        {
            neighbours.Add(gridmap[locationToCheck].GetComponent<PathObject>());
        }

        //Left
        locationToCheck = new Vector2Int(
            currentPathNode.GetTilePosition().x - 1 ,
            currentPathNode.GetTilePosition().y
        );
        if (gridmap.ContainsKey(locationToCheck))
        {
            neighbours.Add(gridmap[locationToCheck].GetComponent<PathObject>());
        }
        Debug.Log(neighbours.Count);
        return neighbours;
    }

}
