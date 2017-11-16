using Entitas;
using UnityEngine;

[Game]
public class MoveComponent : IComponent {
	public float speed;
	public DirectionsEnum direction;

	// Processed
	public Vector2 currentVelocity;
}