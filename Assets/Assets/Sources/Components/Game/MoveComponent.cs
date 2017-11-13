using Entitas;
using UnityEngine;

[Game]
public class MoveComponent : IComponent {
	public float speed;
	public Vector2 currentVelocity;
}