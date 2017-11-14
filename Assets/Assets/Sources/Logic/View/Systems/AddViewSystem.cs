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
		return context.CreateCollector(GameMatcher.Asset);
	}

	protected override bool Filter(GameEntity entity) {
		return entity.hasAsset;
	}

	protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
		foreach (var entity in entities) {
			AssetsEnum selectedAsset = entity.asset.value;
			GameObject gameObject = GetGameObject(selectedAsset);

			if (gameObject != null) {
				gameObject.transform.parent = _viewContainer;
				entity.AddView(gameObject);

				switch (selectedAsset) {
					case AssetsEnum.Tank:
						entity.AddTankView(gameObject.GetComponent<TankView>());
						break;
				}
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

}