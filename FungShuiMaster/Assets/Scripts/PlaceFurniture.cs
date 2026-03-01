using UnityEngine;

public class PlaceFurniture : MonoBehaviour
{
    public GameObject curr = null;
    private Floor floor;

    void Start()
    {
        floor = GameObject.Find("Floor").GetComponent<Floor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curr != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int size = curr.GetComponent<Dimensions>().size;

            Vector2 pos = floor.GetPlacementPos(mousePos, size);

            if (pos == new Vector2(-1, -1))
            {
                curr.SetActive(false);
            }
            else
            {
                curr.SetActive(true);
                curr.transform.position = pos;
            }
        }

        if (Input.GetButtonDown("Place") && curr.active)
        {
            curr = null;
        }
    }
}
