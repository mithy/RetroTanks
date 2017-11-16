using Entitas;
using UnityEngine;

public sealed class FireProjectileSystem : ReactiveSystem<InputEntity> {

	private GameContext _gameContext;

	public FireProjectileSystem(Contexts contexts) : base(contexts.input) {
		_gameContext = contexts.game;
	}

	protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
		return context.CreateCollector(InputMatcher.FireInput);
	}

	protected override bool Filter(InputEntity entity) {
		return entity.hasFireInput;
	}

	protected override void Execute (System.Collections.Generic.List<InputEntity> entities) {
		foreach (var entity in entities) {
			CreateProjectileEntity(entity.fireInput.position, entity.fireInput.direction);
		}
	}

	private void CreateProjectileEntity(Vector2 position, DirectionsEnum direction) {
		var entity = _gameContext.CreateEntity();

		entity.AddAsset(AssetsEnum.Projectile);
		entity.AddPosition(position.x, position.y);
		entity.AddMove(1.5f, direction, Vector2.zero);
	}
}