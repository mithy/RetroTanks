using Entitas;
using System;
using UnityEngine;

public class EnemySpawnSystem : IExecuteSystem {

    private readonly IGroup<GameEntity> _group;
    private Contexts _contexts;

    public EnemySpawnSystem(Contexts contexts) {
        _contexts = contexts;
		_group = contexts.game.GetGroup(Matcher<GameEntity>.AllOf(GameMatcher.Enemy));
    }

    public void Execute() {
		if (_group.GetEntities().Length == 0) {
			SpawnEnemy();
		}
    }

	private void SpawnEnemy() {
		string uuid = Guid.NewGuid().ToString();

		var entity = _contexts.game.CreateEntity();
		entity.AddIndexedEntity(uuid);
		entity.AddAsset(AssetsEnum.Tank);
		entity.AddPosition(2.5f, 2.0f);
		entity.AddMove(0.5f, DirectionsEnum.None, Vector2.zero);
		entity.AddHealth(100);
		entity.isEnemy = true;
	}
}