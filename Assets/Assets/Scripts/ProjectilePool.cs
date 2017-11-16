using System.Collections;
using System.Collections.Generic;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
public class ProjectilePool : MonoBehaviour {

	private Globals _globals;
	private List<GameObject> _projectilesList = new List<GameObject>();

	public void Initialize(Globals globals) {
		_globals = globals;
	}

	public GameObject GetProjectile() {
		for (int i = 0; i < _projectilesList.Count; i++) {
			if (!_projectilesList[i].activeInHierarchy) {
				_projectilesList[i].SetActive(true);
				return _projectilesList[i];
			}
		}

		// Nothing found, instantiate new projectile.
		return CreateNewProjectile();
	}

	private GameObject CreateNewProjectile() {
		GameObject newProjectile = Instantiate(_globals.GetPrefab(AssetsEnum.Projectile));
		newProjectile.transform.SetParent(transform);

		_projectilesList.Add(newProjectile);
		return newProjectile;
	}
}