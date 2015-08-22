using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private Vector2 movement;

	void Start () {
	
	}
	
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");
		movement = new Vector2(inputX, inputY);
	}

	void FixedUpdate () {
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}
