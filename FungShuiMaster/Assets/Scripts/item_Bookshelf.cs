using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class item_Bookshelf : MonoBehaviour
{

	public int thisScore = 10;
	public string BookshelfType = "white";

    public bool isOnFloor = false;
    public bool isUnderWindow = false;
    public bool isAgainstWall = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "architecture_Window")
        {
            isUnderWindow = true;
        }

        if (other.gameObject.tag == "architecture_Wall")
        {
            isAgainstWall = true;
        }

        if (other.gameObject.tag == "floor")
        {
            isOnFloor = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "architecture_Window")
        {
            isUnderWindow = false;
        }
        if (other.gameObject.tag == "architecture_Wall")
        {
            isAgainstWall = false;
        }

        if (other.gameObject.tag == "floor")
        {
            isOnFloor = false;
        }
    }

    public void CheckFung()
    {
        thisScore = 0;
        if (isUnderWindow) { thisScore -= 10; }
        else{thisScore = 0;}

        if (isAgainstWall) { thisScore += 30; }
        else{thisScore -= 10;}

    }



}

