using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//public
	
	//private
	bool touched = false;

	//Events and Delegates
	public delegate void PlayerDeath();
	public static event PlayerDeath playerDeath = delegate{};

	void OnTriggerEnter2D(Collider2D c){
		if(c.gameObject.GetComponentInParent<EnemyController>()){
			gameObject.GetComponentInChildren<MeshRenderer>().enabled = false; //On Player Child sphere
			playerDeath();
		}
	}

	void Update() {
		if(Input.touchCount == 0) return;
			Touch t = Input.GetTouch(0);
		UpdateTouch(t);	
	}

	void UpdateTouch(Touch t){
		if(t.phase == TouchPhase.Began){
			Ray r = Camera.main.ScreenPointToRay(t.position);
			RaycastHit2D hit = Physics2D.GetRayIntersection(r);
			if (hit.collider != null && hit.collider.gameObject.CompareTag("Player")){
				touched = true;
			}
		}

		else if(touched && (t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary)) {
			Vector3 touchPos = t.position;
			touchPos.z = transform.position.z - Camera.main.transform.position.z;
			transform.position = Camera.main.ScreenToWorldPoint(touchPos);
		}
		else if(touched && (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)){
			
		}
	}
}
