using System;
using Entitas;
using UnityEngine;

public sealed class InitPlayerSystem : IInitializeSystem {

	private GameContext _context;

	public InitPlayerSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Initialize() {
		string uuid = Guid.NewGuid().ToString();

		var entity = _context.CreateEntity();
		entity.AddIndexedEntity(uuid);
		entity.AddAsset(AssetsEnum.Tank);
		entity.AddPosition(1, 1);
		entity.AddMove(0.5f, DirectionsEnum.None, Vector2.zero);
		entity.isPlayerInput = true;

		_context.globals.value.PlayerUUID = uuid;
	}
}
