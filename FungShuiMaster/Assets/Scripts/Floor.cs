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

    // Returns <-1, -1> if there is no valid placement
    public Vector2 GetPlacementPos(Vector2 position, Vector2Int size)
    {
        Vector2Int gridPos = Vector3To2(grid.WorldToCell(position));
        // gridPos += size / 2;

        if (0 <= gridPos.x && gridPos.x + size.x <= dimensions.x && 0 <= gridPos.y && gridPos.y + size.y <= dimensions.y)
        {
            Vector2 pos = grid.CellToWorld(Vector2To3(gridPos));
            pos += new Vector2(size.x / 6f, size.y / 2f);

            return pos;
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
