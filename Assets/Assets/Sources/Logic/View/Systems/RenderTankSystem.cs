using Entitas;

public class RenderTankSystem : ReactiveSystem<GameEntity> {

	private Contexts _contexts;

	public RenderTankSystem(Contexts contexts) : base(contexts.game) {
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Move, GameMatcher.TankView));
	}

	protected override bool Filter(GameEntity entity) {
		return entity.hasMove && entity.hasTankView;
	}

	protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
		foreach (var entity in entities) {
			var tankView = entity.tankView;
			var move = entity.move;

			tankView.value.Rotate(move.direction);
			tankView.value.ToggleAnimation(move.direction != DirectionsEnum.None);
		}
	}
}