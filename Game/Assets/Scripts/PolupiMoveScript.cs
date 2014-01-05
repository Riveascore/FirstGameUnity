using UnityEngine;
using System.Collections;

public class PolupiMoveScript : MonoBehaviour {

	public Vector2 polupiXYSpeed = new Vector2(20, 20);
	public float polupiYAmplitude = 1;

	private Vector2 polupiMovement;
	// Use this for initialization
	void Update () {
		float constantLeftMovement = -1;
		polupiMovement = new Vector2 (
			polupiXYSpeed.x * constantLeftMovement,
			Mathf.Sin(transform.position.x)*polupiYAmplitude
		);
	}
	
	// Fixed update calls at same time for all physics applications.
	void FixedUpdate () {
		rigidbody2D.velocity = polupiMovement;
	}
}
