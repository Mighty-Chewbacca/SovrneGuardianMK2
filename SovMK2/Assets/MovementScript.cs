using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public float maxSpeed = 5.0f;
	public bool grounded = false;
	public float jumpForce = 1000.0f;
	Animator charAnimator;


	// Use this for initialization
	void Start () {
		charAnimator = GetComponent<Animator> ();
	}

	void FixedUpdate(){

		float move = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);


		if (move == 0) {
						charAnimator.SetBool ("isMoving", false);
				} else
						charAnimator.SetBool ("isMoving", true);

		

			if (grounded) {

			if (Input.GetKey (KeyCode.Space)) {
				rigidbody2D.AddForce (new Vector2 (0, jumpForce));

			}
		}
	}

	void OnCollisionEnter2D(){
		charAnimator.SetBool("isGrounded",true);
		grounded = true;
	}

	void OnCollisionExit2D(){
		charAnimator.SetBool("isGrounded",false);
		grounded = false;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
