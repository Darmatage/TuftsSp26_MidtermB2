using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class DragAndDrop : MonoBehaviour
{
    public GameObject[] directions;
    public GameObject hoverSprite;
    public int currentDirection;
    private bool selected;
    
    private bool hovering;



    private void Start()
    {
        hoverSprite.SetActive(false);
        ChangeDirection();
    }

    void Update()
    {
        if (selected == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }

        if (hovering) { 
        if (Input.GetKeyDown("up"))
        {
            currentDirection = 3; //Upper Left
            ChangeDirection();
        }

        if (Input.GetKeyDown("down"))
        {
            currentDirection = 1; //Lower Left
            ChangeDirection();
        }

        if (Input.GetKeyDown("left"))
        {
            currentDirection = 0; //Lower Right
            ChangeDirection();
        }

        if (Input.GetKeyDown("right"))
        {
            currentDirection = 2; //Upper Right
            ChangeDirection();
        }
    }

    }

    void OnMouseOver()
    {
        hovering=true;
        hoverSprite.SetActive(true);
        //GetComponentInChildren<SpriteRenderer>().color = Color.red;
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }

    private void OnMouseExit()
    {
        hovering=false;
        hoverSprite.SetActive(false);
        //GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

   void ChangeDirection()
    {
        for (int i = 0; i < directions.Length; i++)
        {
            directions[i].SetActive(false);
        }

        directions[currentDirection].SetActive(true);
    }

}