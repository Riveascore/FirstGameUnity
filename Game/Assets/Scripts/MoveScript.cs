using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public Vector2 speed = new Vector2(50, 50);
	private Vector2 movement;
	public Vector3 direction;

	void Update() {
		movement = new Vector2 (
			speed.x * direction.x,
			0);
	}

	void FixedUpdate() {
		rigidbody2D.velocity = movement;
	}
}
