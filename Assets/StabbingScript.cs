using UnityEngine;
using System.Collections;

public class StabbingScript : MonoBehaviour {

	int stabCount;
	GameObject player;
	Animator playeranim;
	bool overSigil;

	public AudioClip stabbingSound;
	AudioSource source;

	void Start () {
		stabCount = 0;
		player = GameObject.Find ("player");
		playeranim = (Animator)player.GetComponent<Animator> ();
		setOverSigil (false);

		source = GetComponent<AudioSource> ();
	}
	
	void Update () {
		if (overSigil) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				print ("stabbing");
				playeranim.SetBool ("isStabbing", true);
				stabCount++;
				source.PlayOneShot(stabbingSound);
			}
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			playeranim.SetBool ("isStabbing", false);
		}

		if (stabCount >= 5) {
			GameObject gm = GameObject.Find ("GameManager");
			((GameScript) gm.GetComponent(typeof(GameScript))).win();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "player") {
			setOverSigil(true);
		}
	}

	void OnTriggerStay2D(){
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == "player") {
			setOverSigil(false);
		}
	}

	void setOverSigil(bool isover){
		playeranim.SetBool ("isOverSigil", isover);
		overSigil = isover;
	}
}
