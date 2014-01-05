using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour {


	// Define a scrolling speed:
	public Vector2 speed = new Vector2(2, 2);
	public Vector2 direction = new Vector2(-1, 0);


	//Movement should be applied to camera
	public bool isLinkedToCamera = false;

	void Update() {

		//Define the movement type
		Vector3 movement = new Vector3 (
			speed.x * direction.x,
			speed.y * direction.y,
			0);
		//Have this move every deltaTime
		movement *= Time.deltaTime;

		if (isLinkedToCamera) {
			Camera.main.transform.Translate(movement);
		}
	}
}