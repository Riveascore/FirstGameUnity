using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 playerMaxVelocity = new Vector2(50, 50);
	// Inputs -1..1 will define how much of this max velocity is used

	private Vector2 playerMovement;
	// Use this for initialization
	void Update () {
		// get axis info from keyboard input?
		// will be -1..1
		float verticalInputValue = Input.GetAxis ("Vertical");
		float horizontalInputValue = Input.GetAxis ("Horizontal");

		playerMovement = new Vector2 (
			horizontalInputValue * playerMaxVelocity.x,
			verticalInputValue * playerMaxVelocity.y
		);

		//Deal with shooting here:
		bool shoot = Input.GetButtonDown ("Fire1");
		shoot |= Input.GetButtonDown ("Fire2");

		if (shoot) {
			WeaponScript weapon = GetComponentInChildren<WeaponScript>();	
			weapon.Attack(false);
		}
	}
	
	// Fixed update is called in sync with the physics engine for each time physics is calculated for entire game
	void FixedUpdate () {
		rigidbody2D.velocity = playerMovement;
	}
}
