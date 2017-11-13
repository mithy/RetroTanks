using Entitas;
using UnityEngine;

public class MoveSystem : IExecuteSystem {

	private readonly IGroup<GameEntity> _group;
	private Contexts _contexts;

	public MoveSystem(Contexts contexts) {
		_contexts = contexts;
		_group = contexts.game.GetGroup(Matcher<GameEntity>.AllOf(GameMatcher.Move, GameMatcher.Position, GameMatcher.TankView));
	}

	public void Execute() {
		foreach (var entity in _group.GetEntities()) {
			Vector2Int velocity = ProcessDirection(entity.tankView.currentDirection);

			var move = entity.move;
			var pos = entity.position;

			Vector2 currentVelocity = new Vector2(velocity.x * move.speed * Time.deltaTime, 
				velocity.y * move.speed * Time.deltaTime);

			entity.ReplaceMove(move.speed, currentVelocity);
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