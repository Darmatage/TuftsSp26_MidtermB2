using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class item_Rug : MonoBehaviour
{

	public int thisScore = 20;
	public string RugType = "ficus";

	public bool isOnFloor = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "floor")
		{
			isOnFloor = true;
		}
    }

	void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "floor")
		{
			isOnFloor = false;
		}
    }



}
