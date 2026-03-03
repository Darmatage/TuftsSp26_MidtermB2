using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class DragAndDrop_simple : MonoBehaviour
{
    //public GameObject[] directions;
    //public GameObject hoverSprite;
    //public int currentDirection;
    private bool selected;
    
    private bool hovering;



    private void Start()
    {
        //hoverSprite.SetActive(false);
        //ChangeDirection();
    }

    void Update()
    {
        if (selected)
        {
            Vector3 mousePos = Input.mousePosition;

            // This is critical in 2D
            mousePos.z = Mathf.Abs(Camera.main.transform.position.z);

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            // Preserve original Z so it doesn't disappear
            worldPos.z = transform.position.z;

            transform.position = worldPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }
    }


    void OnMouseOver()
    {
        hovering=true;
        //hoverSprite.SetActive(true);
        //GetComponentInChildren<SpriteRenderer>().color = Color.red;
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }

    private void OnMouseExit()
    {
        hovering=false;
        //hoverSprite.SetActive(false);
        //GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

/*
   void ChangeDirection()
    {
        for (int i = 0; i < directions.Length; i++)
        {
            directions[i].SetActive(false);
        }

        directions[currentDirection].SetActive(true);
    }
	*/

}