using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{

	public int hp = 2;
	public bool isEnemy = true;

	void OnTriggerEnter2D(Collider2D collider) {
		//We check if this object is a shot or not
		ShotScript colliderShotScript = collider.gameObject.GetComponent<ShotScript> ();
		if (colliderShotScript != null) {

			//This is how we avoid friendly fire
			if(colliderShotScript.shotIsFiredByEnemy != isEnemy) {
				hp -= colliderShotScript.damage;

				//We want to destroy shot object if it hits an enemy
				Destroy (collider.gameObject);
			}
			if(hp <= 0) {
				Destroy (gameObject);
			}

		}
	}	
}