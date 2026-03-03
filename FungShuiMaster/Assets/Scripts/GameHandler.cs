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

	public int currentFungScore = 0;
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
		currentFungScore = 0;
		//check the beds
	/*
		//Item_Bed bed = GameObject.FindWithTag("item_Bed").GetComponent<Item_Bed>();
		//bed.CheckFung();
		//int bedScore = bed.thisScore;
		GameObject bed = GameObject.FindWithTag("item_Bed");
		Item_Bed bedItem = bed.GetComponent<Item_Bed>();
		//.CheckFung();
		int bedScore = bedItem.thisScore;
		currentFungScore += bedScore;
	*/
		//check the mirror

		//check for plants
		if (GameObject.FindWithTag("item_Plant") != null)
		{ 
			currentFungScore +=20;
			string myPlantType = GameObject.FindWithTag("item_Plant").GetComponent<item_Plant>().plantType;
			Debug.Log("PLANT type: " + myPlantType);
		
		}
		else {currentFungScore -=20;}
		

		updateStatsDisplay();
	}

	public void updateStatsDisplay(){
            scoreText.text = "SCORE: " + currentFungScore;	
	}



/*
      public void playerGetHit(int damage){
           if (isDefending == false){
                  playerHealth -= damage;
                  if (playerHealth >=0){
                        updateStatsDisplay();
                  }
                  if (damage > 0){
                        //play GetHit animation:
                        player.GetComponent<PlayerHurt>().playerHit();
                  }
            }

           if (playerHealth > StartPlayerHealth){
                  playerHealth = StartPlayerHealth;
                  updateStatsDisplay();
            }

           if (playerHealth <= 0){
                  playerHealth = 0;
                  updateStatsDisplay();
                  playerDies();
            }
      }
*/
      
      public void playerDies(){
            //player.GetComponent<PlayerHurt>().playerDead();       //play Death animation
            lastLevelDied = sceneName;       //allows replaying the Level where you died
            StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
            //player.GetComponent<PlayerMove>().isAlive = false;
            //player.GetComponent<PlayerJump>().isAlive = false;
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("EndLose");
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