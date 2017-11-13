using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class RenderPositionSystem : ReactiveSystem<GameEntity> {

	public RenderPositionSystem(Contexts contexts) : base(contexts.game) {
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.View));
	}

	protected override bool Filter(GameEntity entity) {
		return entity.hasView && entity.hasPosition;
	}

	protected override void Execute(List<GameEntity> entities) {
		foreach (var e in entities) {
			var pos = e.position;
			e.view.value.transform.position = new Vector2(pos.x, pos.y);
		}
	}
}
