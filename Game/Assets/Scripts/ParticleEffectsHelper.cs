using UnityEngine;
using System.Collections;

public class ParticleEffectsHelper : MonoBehaviour {

	public static ParticleEffectsHelper Instance;

	public ParticleSystem smokeEffect;
	public ParticleSystem fireParticleEffect;

	void Awake() {
		if (Instance != null) {
			Debug.LogError ("Multiple instances of ParticleEffectsHelper");
		}
		Instance = this;
	}

	public void Explosion(Vector3 position) {
		instantiate (smokeEffect, position);
		instantiate (fireParticleEffect, position);
	}

	private ParticleSystem instantiate(ParticleSystem ourPrefab, Vector3 position) {
		ParticleSystem newParticleSystem = Instantiate (
			ourPrefab,
			position,
			Quaternion.identity) as ParticleSystem;

		Destroy (
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
		);

		return newParticleSystem;
	}
}
