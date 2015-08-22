using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {

	GameObject player;

	void Start () {
		player = GameObject.Find ("player");
	}
	
	void Update () {
	
	}

	void OnCollisionStay2D(){
		if (Input.GetKey (KeyCode.DownArrow)) {
			GetComponent<Collider2D>().isTrigger = true;
			((PlayerScript)player.GetComponent(typeof(PlayerScript))).startsClimbing();
		}
	}

	void OnTriggerExit2D(){
		GetComponent<Collider2D>().isTrigger = false;
		((PlayerScript)player.GetComponent(typeof(PlayerScript))).startsAdventuring();
	}
}
