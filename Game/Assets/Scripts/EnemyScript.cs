using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private WeaponScript[] weapons;

	void Awake() {
		weapons = GetComponentsInChildren<WeaponScript> ();
	}

	void Update() {
		//Set polupi to auto-fire
		foreach(WeaponScript weapon in weapons) {
			if (weapon != null && weapon.canAttack) {
				//Indicating this weapon is firing FROM an enemy.
				weapon.Attack (true);
			}
		}
	}
}
