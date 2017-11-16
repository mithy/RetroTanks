using Entitas;
using UnityEngine;

public class MoveSystem : IExecuteSystem {

	private readonly IGroup<GameEntity> _group;
	private Contexts _contexts;

	public MoveSystem(Contexts contexts) {
		_contexts = contexts;
		_group = contexts.game.GetGroup(Matcher<GameEntity>.AllOf(GameMatcher.Move, GameMatcher.Position));
        
	}

	public void Execute() {
		foreach (var entity in _group.GetEntities()) {
			float speed = entity.move.speed;
			DirectionsEnum direction = entity.move.direction;
			Vector2Int velocity = ProcessDirection(direction);

			Vector2 currentVelocity = new Vector2(velocity.x * speed * Time.deltaTime, 
				velocity.y * speed * Time.deltaTime);

			entity.ReplaceMove(speed, direction, currentVelocity);
		}
	}

	private Vector2Int ProcessDirection(DirectionsEnum direction) {
		switch (direction) {
			case DirectionsEnum.Up:
				return new Vector2Int(0, 1);

			case DirectionsEnum.Down:
				return new Vector2Int(0, -1);	

			case DirectionsEnum.Left:
				return new Vector2Int(-1, 0);

			case DirectionsEnum.Right:
				return new Vector2Int(1, 0);
		}

		return Vector2Int.zero;
	}
}