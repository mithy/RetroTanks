using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileView : MonoBehaviour {

	private EntityLink _entityLink;

	private void Awake() {
		_entityLink = GetComponent<EntityLink>();
	}

	private void OnCollisionEnter2D(Collision2D coll) {
		EntityLink collidedWith = coll.collider.gameObject.GetComponent<EntityLink>();
		_entityLink?.Entity?.AddProjectileHit(collidedWith?.Entity);
	}
}