using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileView : MonoBehaviour {

	private EntityLink _entityLink;

	private void Awake() {
		_entityLink = GetComponent<EntityLink>();
	}

	private void OnCollisionEnter2D(Collision2D coll) {
		if (_entityLink.Entity != null) {
			_entityLink.Entity.ReplaceProjectileHit(true);
		}
	}
}