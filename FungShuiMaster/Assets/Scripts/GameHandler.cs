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
    public TextMeshProUGUI ResponseText;

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
        string responseMessage = "";
		currentFengScore = 0;
		//check the beds
		if (GameObject.FindWithTag("item_Bed") != null)
		{ 
			Item_Bed bed = GameObject.FindWithTag("item_Bed").GetComponent<Item_Bed>();
			bed.CheckFung();
			int bedScore = bed.thisScore;
			currentFengScore += bedScore;
            responseMessage += "BED:\n";

            if (bed.isUnderWindow)
            {
                currentFengScore -= 10;
                responseMessage += "Under window? YES (-10)\n";
            }
            else
            {
                responseMessage += "Under window? NO (0)\n";
            }

            if (bed.isAcrossFromDoor)
            {
                currentFengScore -= 15;
                responseMessage += "Across from door? YES (-15)\n";
            }
            else
            {
                responseMessage += "Across from door? NO (0)\n";
            }

            if (bed.isAcrossMirror)
            {
                currentFengScore -= 20;
                responseMessage += "Across from mirror? YES (-20)\n";
            }
            else
            {
                responseMessage += "Across from mirror? NO (0)\n";
            }

            if (bed.isAgainstWall)
            {
                currentFengScore += 10;
                responseMessage += "Against wall? YES (+10)\n";
            }
            else
            {
                responseMessage += "Against wall? NO (0)\n";
            }

            responseMessage += "\n";

        }

        //check the mirror

        //check the desk
         if (GameObject.FindWithTag("item_Desk") != null)
		{ 
			item_Desk Desk = GameObject.FindWithTag("item_Desk").GetComponent<item_Desk>();
			Desk.CheckFung();
			int deskScore = Desk.thisScore;
			currentFengScore += deskScore;
            if (Desk.isAgainstWall)
            {
                currentFengScore += 10;
                responseMessage += "DESK:\n";
                responseMessage += "Against wall? YES (+10)\n";
            }
            else
            {
                currentFengScore = 0;
                responseMessage += "DESK:\n";
                responseMessage += "Against wall? NO (0) \n\n";
            }
            }
      

        //check the bookself
        if (GameObject.FindWithTag("item_Bookshelf") != null)
		{ 
			item_Bookshelf bookshelf = GameObject.FindWithTag("item_Bookshelf").GetComponent<item_Bookshelf>();
			bookshelf.CheckFung();
			int bookshelfScore = bookshelf.thisScore;
			currentFengScore += bookshelfScore;
            responseMessage += "BOOKSHELF:\n";
            if (bookshelf.isAgainstWall)
            {
                currentFengScore += 10;
                responseMessage += "Against wall? YES (+10)\n";
            }
            else
            {
                responseMessage += "Against wall? NO (0)\n";
            }

            if (bookshelf.isUnderWindow)
            {
                currentFengScore -= 10;
                responseMessage += "Under window? YES (-10)\n";
            }
            else
            {
                responseMessage += "Under window? NO (0)\n";
            }
        }

        //check for plants
        if (GameObject.FindWithTag("item_Plant") != null)
		{ 
			item_Plant myPlant = GameObject.FindWithTag("item_Plant").GetComponent<item_Plant>();
			if (myPlant.isOnFloor)
			{
				currentFengScore +=20;
				string myPlantType = myPlant.plantType;
                responseMessage += "PLANT:\n";
                responseMessage += "Type: " + myPlantType + "\n";
                responseMessage += "On floor? (+20) YES\n\n";
            }
            else {currentFengScore -=20;
            responseMessage += "PLANT:\nOn floor? (-20) NO\n\n";}

        }
        else {currentFengScore -=20;}

        //check for rug
        if (GameObject.FindWithTag("item_Rug") != null)
        {
            item_Rug myRug = GameObject.FindWithTag("item_Rug").GetComponent<item_Rug>();
            if (myRug.isOnFloor)
            {
                currentFengScore += 10;
                responseMessage += "RUG: \n";
                responseMessage += "Exists on floor? (+10) Yes \n\n";
            }
            else { currentFengScore = 0;
                responseMessage += "RUG: Doesn't exist on floor (-0)\n\n";
            }
        }
        else { currentFengScore -= 10; }

        ResponseText.text = responseMessage;

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