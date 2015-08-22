using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private Vector2 movement;

	enum State {
		Climbing,
		Adventuring
	}

	State state;

	void Start () {
		state = State.Adventuring;
	}
	
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");
		movement = new Vector2(2* inputX, 2* inputY);

		switch (state) {
		case State.Climbing:
			GetComponent<Rigidbody2D>().gravityScale = 0;

			break;
		case State.Adventuring:
			GetComponent<Rigidbody2D>().gravityScale = 15;

			break;
		default:
			break;
		}
	}

	void FixedUpdate () {
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	public void startsClimbing() {
		state = State.Climbing;
	}

	public void startsAdventuring() {
		state = State.Adventuring;
	}
}
