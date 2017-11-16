using System;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, CreateAssetMenu]
public class Globals : ScriptableObject {

	[SerializeField]
	private GameObject TankPrefab;

	[SerializeField]
	private GameObject ProjectilePrefab;

	private string _playerUUID = string.Empty;
	public string PlayerUUID {
		get {
			return _playerUUID;
		}

		set {
			_playerUUID = value;
		}
	}

	public GameObject GetPrefab(AssetsEnum asset) {
		switch (asset) {
			case AssetsEnum.Tank:
				return TankPrefab;

			case AssetsEnum.Projectile:
				return ProjectilePrefab;
		}

		throw new Exception("Asset " + asset.ToString() + " not found.");
	}
}