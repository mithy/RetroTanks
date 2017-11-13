using System;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, CreateAssetMenu]
public class Globals : ScriptableObject {

	[SerializeField]
	private GameObject TankPrefab;

	public GameObject GetPrefab(AssetsEnum asset) {
		switch (asset) {
			case AssetsEnum.Tank:
				return TankPrefab;
		}

		throw new Exception("Asset " + asset.ToString() + " not found.");
		return null;
	}

}