using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class item_Desk : MonoBehaviour
{

	public bool isAgainstWall = false;

	public int thisScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
       
		if (other.gameObject.tag == "architecture_Wall")
		{
			isAgainstWall=true;
		}
    }

	void OnTriggerExit2D(Collider2D other)
    {
      
		if (other.gameObject.tag == "architecture_Wall")
		{
			isAgainstWall=false;
		}
    }

	public void CheckFung()
	{
		if (isAgainstWall){thisScore += 10;} 
		//else{thisScore -= 10;}

	}



}
