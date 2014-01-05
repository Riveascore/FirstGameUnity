using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	//This Transform is to set which shot object will be used with the weapon
	public Transform shotPrefab;
	public float shootingRate = 0.25f;

	//Making this public so we can set certain enemies to shoot later, so not all polupis are shooting at the exact same time
	public float shootCooldown = 0f	;


	void Update() {
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}
	}
	//Want to create a new "shot" if possible, if cooldown is 0?
	public void Attack(bool isEnemy) {
		if (canAttack) {
			shootCooldown = shootingRate;
			// Create a new shot gameObject
			var shotTransform = Instantiate(shotPrefab) as Transform;

			//Assign position to start in object shooting
			shotTransform.position = transform.position;

			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

			//Give shot "is enemy" value
			if (shot != null) {
				shot.shotIsFiredByEnemy = isEnemy;
			}
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if(move != null) {
				//Whichever way is the "right" side for the weapon, in case the weapon is upside down
				move.direction = this.transform.right;
			}

		}
	}

	public bool canAttack {
		get{
			return shootCooldown <= 0f;
		}
	}
}
