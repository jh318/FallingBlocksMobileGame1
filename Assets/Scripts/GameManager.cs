using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	void Awake(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
		} 
		else Destroy(gameObject);
	}

	void OnEnable(){
		PlayerController.playerDeath += PlayerDeath;
		SceneManager.sceneLoaded += SceneLoaded;
	}

	void OnDisable(){
		PlayerController.playerDeath -= PlayerDeath;
	}

	void Update(){
		
	}

	//Functions
	private void PlayerDeath(){
		SceneManager.LoadScene("GameOverScene");	
	}

	private void SceneLoaded(Scene scene, LoadSceneMode mode){
		if(scene.name == "GameOverScene"){
			Debug.Log("Game Over");

		}
	}

	private void StartGame(){
		
		
	}
}
