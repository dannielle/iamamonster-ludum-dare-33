using UnityEngine;
using System.Collections;

public class StabbingScript : MonoBehaviour {

	int stabCount;

	void Start () {
		stabCount = 0;
	}
	
	void Update () {
		if (stabCount >= 10) {
			GameObject gm = GameObject.Find ("GameManager");
			((GameScript) gm.GetComponent(typeof(GameScript))).win();
		}
	}

	void OnTriggerStay2D(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			print("stab");
			stabCount++;
		}
	}
}
