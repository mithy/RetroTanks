using Entitas;
using UnityEngine;

public sealed class ProcessProjectileHitSystem : ReactiveSystem<GameEntity>, ICleanupSystem {

	private readonly IGroup<GameEntity> _collidedProjectiles;

	public ProcessProjectileHitSystem(Contexts contexts) : base(contexts.game) {
		_collidedProjectiles = contexts.game.GetGroup(GameMatcher.ProjectileHit);
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.ProjectileHit);
	}

	protected override bool Filter(GameEntity entity) {
		return entity.hasProjectileHit;
	}

	protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
		foreach (var entity in entities) {
			EntityLink entityLink = entity.view.value.GetComponent<EntityLink>();
			entityLink?.Unlink();

			entity.view.value.SetActive(false);
		}
	}

	public void Cleanup() {
		foreach (var projectile in _collidedProjectiles.GetEntities()) {
			projectile.Destroy();
		}
	}
}