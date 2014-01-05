using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public int damage = 1;
	public bool shotIsFiredByEnemy = false;	

	void start() {
		//Destroy the "shot" after 20 seconds;
		Destroy (gameObject, 20);
	}
}
