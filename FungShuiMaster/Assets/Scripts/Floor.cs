using UnityEngine;

public class Floor : MonoBehaviour
{
    // Up and right is "x", up and left is "y"
    public Vector2Int dimensions;
    public Transform bed;
    private Grid grid;
    private Vector2 tileDims = new Vector2(1f, 0.5f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldMouse = Camera.main.ScreenToWorldPoint(mousePos);
        bed.position = GetPlacementPos(worldMouse, new Vector2Int(3, 4));
    }

    // Returns <-1, -1> if there is no valid placement
    public Vector2 GetPlacementPos(Vector2 position, Vector2Int size)
    {
        Vector2Int gridPos = Vector3To2(grid.WorldToCell(position));

        if (0 <= gridPos.x && gridPos.x + size.x < dimensions.x && 0 <= gridPos.y && gridPos.y + size.y < dimensions.y)
        {
            Vector2 left = grid.CellToWorld(Vector2To3(gridPos));
            Vector2 right = grid.CellToWorld(Vector2To3(gridPos + size));

            return (left + right) / 2;
        }

        return new Vector2(-1, -1);
    }

    Vector2Int Vector3To2(Vector3Int vect)
    {
        return new Vector2Int(vect.x, vect.y);
    }

    Vector3Int Vector2To3(Vector2Int vect)
    {
        return new Vector3Int(vect.x, vect.y, 0);
    }
}
