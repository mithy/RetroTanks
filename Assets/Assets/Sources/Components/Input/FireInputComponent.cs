using Entitas;
using UnityEngine;

[Input]
public class FireInputComponent : IComponent {
	public Vector3 position;
	public DirectionsEnum direction;
}