using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

      //private GameObject player;
      //public static int playerHealth = 100;
      //public int StartPlayerHealth = 100;
      //public TMP_Text healthText;

	public int currentFengScore = 0;
	public TMP_Text scoreText;

      private string sceneName;
      public static string lastLevelDied;  //allows replaying the Level where you died

      void Start(){
            //player = GameObject.FindWithTag("Player");
            sceneName = SceneManager.GetActiveScene().name;
            //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
                  //playerHealth = StartPlayerHealth;
            //}
            //updateStatsDisplay();
      }

	public void CheckAllFung()
	{
		currentFengScore = 0;
		//check the beds
		if (GameObject.FindWithTag("item_Bed") != null)
		{ 
			Item_Bed bed = GameObject.FindWithTag("item_Bed").GetComponent<Item_Bed>();
			bed.CheckFung();
			int bedScore = bed.thisScore;
			currentFengScore += bedScore;
			Debug.Log("BED is: under window? " + bed.isUnderWindow + 
			", across from door? " + bed.isAcrossFromDoor + 
			", across from a mirror? " + bed.isAcrossMirror + 
			", against a Wall?" + bed.isAgainstWall);
		}

		//check the mirror

         //check the bookself
        if (GameObject.FindWithTag("item_Bookshelf") != null)
		{ 
			item_Bookshelf bookshelf = GameObject.FindWithTag("item_Bookshelf").GetComponent<item_Bookshelf>();
			bookshelf.CheckFung();
			int bookshelfScore = bookshelf.thisScore;
			currentFengScore += bookshelfScore;
			Debug.Log("BOOKSHELF is: under window? " + bookshelf.isUnderWindow + 
			", against a Wall?" + bookshelf.isAgainstWall);
		}
		
		//check for plants
		if (GameObject.FindWithTag("item_Plant") != null)
		{ 
			item_Plant myPlant = GameObject.FindWithTag("item_Plant").GetComponent<item_Plant>();
			if (myPlant.isOnFloor)
			{
				currentFengScore +=20;
				string myPlantType = myPlant.plantType;
				Debug.Log("PLANT type: " + myPlantType);
			}
			else {currentFengScore -=20;}
		}
		else {currentFengScore -=20;}

        //check for rug
        if (GameObject.FindWithTag("item_Rug") != null)
        {
            item_Rug myRug = GameObject.FindWithTag("item_Rug").GetComponent<item_Rug>();
            if (myRug.isOnFloor)
            {
                currentFengScore += 10;
                string myRugType = myRug.RugType;
                Debug.Log("Rug type: " + myRugType);
            }
            else { currentFengScore -= 10; }
        }
        else { currentFengScore -= 10; }

        //Display new score:
        updateStatsDisplay();
	}

	public void updateStatsDisplay(){
            scoreText.text = "SCORE: " + currentFengScore;	
	}

      

      public void StartGame() {
            SceneManager.LoadScene("Level1");
      }

      // Return to MainMenu
      public void RestartGame() {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
             // Reset all static variables here, for new games:
            //playerHealth = StartPlayerHealth;
      }

      // Replay the Level where you died
      public void ReplayLastLevel() {
            Time.timeScale = 1f;
            SceneManager.LoadScene(lastLevelDied);
             // Reset all static variables here, for new games:
            //playerHealth = StartPlayerHealth;
      }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
      }
} 