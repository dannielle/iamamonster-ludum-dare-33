using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private Vector2 movement;

	Animator anim;

	enum State {
		Climbing,
		Adventuring
	}

	State state;

	void Start () {
		state = State.Adventuring;
		anim = GetComponent<Animator> ();
	}
	
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");
		movement = new Vector2(2* inputX, 2* inputY);

		switch (state) {
		case State.Climbing:
			GetComponent<Rigidbody2D>().gravityScale = 0;
			anim.SetBool("isClimbing", true);
			break;
		case State.Adventuring:
			GetComponent<Rigidbody2D>().gravityScale = 15;
			anim.SetBool("isClimbing", false);
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
