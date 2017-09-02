using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public delegate void PlayerDeath();
	public static event PlayerDeath playerDeath = delegate{};

	void OnTriggerEnter2D(Collider2D c){
		if(c.gameObject.GetComponentInParent<EnemyController>()){
			gameObject.GetComponentInChildren<MeshRenderer>().enabled = false; //On Player Child sphere
			playerDeath();
		}
	}
}
