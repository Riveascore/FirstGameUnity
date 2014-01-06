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
			SoundEffectsHelper.Instance.MakePlayerShotSound();
		}


		KeepPlayerInCameraBounds ();
	}
	
	// Fixed update is called in sync with the physics engine for each time physics is calculated for entire game
	void FixedUpdate () {
		rigidbody2D.velocity = playerMovement;
	}

	void OnDestroy() {
		transform.parent.gameObject.AddComponent<GameOverScript> ();
	}

	private void KeepPlayerInCameraBounds() {
		//Here's where we handle keeping player in bounds of camera
		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);
	}
}
