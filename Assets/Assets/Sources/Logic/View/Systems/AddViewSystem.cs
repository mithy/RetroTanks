using System;
using Entitas;
using UnityEngine;

public sealed class AddViewSystem : ReactiveSystem<GameEntity> {

	private const string VIEWS_CONTAINER = "Views";

	private readonly Transform _viewContainer = new GameObject(VIEWS_CONTAINER).transform;
	private Contexts _contexts;

	public AddViewSystem(Contexts contexts) : base(contexts.game) {
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Asset, GameMatcher.Position));
	}

	protected override bool Filter(GameEntity entity) {
		return entity.hasAsset && entity.hasPosition;
	}

	protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
		foreach (var entity in entities) {
			AssetsEnum selectedAsset = entity.asset.value;
			GameObject gameObject = GetGameObject(selectedAsset);

			if (gameObject != null) {
				AttachGameObjectToEntity(gameObject, entity);
				AddAditionalEntityComponents(selectedAsset, gameObject, entity);
			}
		}
	}

	private GameObject GetGameObject(AssetsEnum selectedAsset) {
		switch (selectedAsset) {
			case AssetsEnum.Tank:
				return GameObject.Instantiate(_contexts.game.globals.value.GetPrefab(selectedAsset));

			case AssetsEnum.Projectile:
				return _contexts.game.projectilePool.value.GetProjectile();
		}

		return null;
	}

	private void AttachGameObjectToEntity(GameObject gameObject, GameEntity entity) {
		gameObject.transform.parent = _viewContainer;
		gameObject.transform.position = new Vector3(entity.position.x, entity.position.y, 0);
		entity.AddView(gameObject);

		EntityLink entityLink = gameObject.GetComponent<EntityLink>();

		if (entityLink != null) {
			entityLink.Link(entity);
		}
	}

	private void AddAditionalEntityComponents(AssetsEnum selectedAsset, GameObject gameObject, GameEntity entity) {
		switch (selectedAsset) {
			case AssetsEnum.Tank:
				entity.AddTankView(gameObject.GetComponent<TankView>());
				break;
		}
	}
}