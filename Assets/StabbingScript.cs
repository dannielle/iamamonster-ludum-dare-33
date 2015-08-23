using UnityEngine;
using System.Collections;

public class StabbingScript : MonoBehaviour {

	int stabCount;
	GameObject player;
	Animator playeranim;

	void Start () {
		stabCount = 0;
		player = GameObject.Find ("player");
		playeranim = (Animator)player.GetComponent<Animator> ();
		playeranim.SetBool ("isOverSigil", false);
	}
	
	void Update () {
		if (stabCount >= 10) {
			GameObject gm = GameObject.Find ("GameManager");
			((GameScript) gm.GetComponent(typeof(GameScript))).win();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "player") {
			playeranim.SetBool ("isOverSigil", true);
		}
	}

	void OnTriggerStay2D(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			playeranim.SetBool ("isStabbing", true);
			stabCount++;
		} else {
			playeranim.SetBool("isStabbing", false);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == "player") {
			playeranim.SetBool ("isOverSigil", false);
		}
	}
}
