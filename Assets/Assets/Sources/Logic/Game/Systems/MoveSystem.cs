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
		Vector2Int velocity = ProcessDirection(_contexts.input.directionInput.value);

		foreach (var entity in _group.GetEntities()) {
			var move = entity.move;
			var pos = entity.position;

			entity.ReplacePosition(pos.x + (velocity.x * move.speed * Time.deltaTime), pos.y + (velocity.y * move.speed * Time.deltaTime));
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