using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, CreateAssetMenu]
public class Globals : ScriptableObject {

	public GameObject TankPrefab;

}