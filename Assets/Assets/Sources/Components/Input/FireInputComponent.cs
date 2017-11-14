using Entitas;
using UnityEngine;

[Input]
public class FireInputComponent : IComponent {
	public Vector2 position;
	public DirectionsEnum direction;
}