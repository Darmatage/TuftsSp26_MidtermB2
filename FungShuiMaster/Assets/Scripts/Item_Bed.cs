using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item_Bed : MonoBehaviour
{

	public bool isUnderWindow = false;
	public bool isAcrossFromDoor = false;
	public bool isAcrossMirror = false;
	public bool isAgainstWall = false;

	public int thisScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "architecture_Window")
		{
			isUnderWindow=true;
		}
		if (other.gameObject.tag == "architecture_Door")
		{
			isAcrossFromDoor=true;
		}
		if (other.gameObject.tag == "item_Mirror")
		{
			isAcrossMirror=true;
		}
		if (other.gameObject.tag == "architecture_Wall")
		{
			isAgainstWall=true;
		}
    }

	void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "architecture_Window")
		{
			isUnderWindow=false;
		}
		if (other.gameObject.tag == "architecture_Door")
		{
			isAcrossFromDoor=false;
		}
		if (other.gameObject.tag == "item_Mirror")
		{
			isAcrossMirror=false;
		}
		if (other.gameObject.tag == "architecture_Wall")
		{
			isAgainstWall=false;
		}
    }

	public void CheckFung()
	{
		thisScore = 0;
		if (isUnderWindow){thisScore -= 10;} 
		//else{thisScore += 10;}

		if (isAcrossFromDoor){thisScore -= 30;} 
		//else{thisScore += 10;}

		if (isAcrossMirror){thisScore -= 30;} 
		//else{thisScore += 30;}

		if (isAgainstWall){thisScore += 30;} 
		//else{thisScore -= 5;}

	}



}
