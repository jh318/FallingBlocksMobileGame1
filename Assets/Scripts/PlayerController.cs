using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c){
		if(c.gameObject.GetComponentInParent<EnemyController>()){
			gameObject.GetComponentInChildren<MeshRenderer>().enabled = false; //On Player Child sphere
		}
	}
}
