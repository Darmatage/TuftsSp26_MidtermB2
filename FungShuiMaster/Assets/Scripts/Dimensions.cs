using UnityEngine;

public class Dimensions : MonoBehaviour
{
    public Vector2Int size;
    public string name;
    private PlaceFurniture place;

    void Start()
    {
        place = GameObject.Find("PlaceHandler").GetComponent<PlaceFurniture>();
    }

    public void OnMouseOver()
    {
        if (Input.GetButtonDown("Place") && place.curr == null)
        {
            place.curr = gameObject;
        }
    }
}
