using Entitas;

public class RenderTankSystem : ReactiveSystem<GameEntity> {

	private Contexts _contexts;

	public RenderTankSystem(Contexts contexts) : base(contexts.game) {
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.TankView);
	}

	protected override bool Filter(GameEntity entity) {
		return entity.hasTankView;
	}

	protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
		foreach (var entity in entities) {
			var tankView = entity.tankView;

			tankView.value.Rotate(tankView.currentDirection);
			tankView.value.ToggleAnimation(tankView.currentDirection != DirectionsEnum.None);
		}
	}
}