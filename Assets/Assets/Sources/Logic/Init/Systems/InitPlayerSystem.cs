using Entitas;
using UnityEngine;

public sealed class InitPlayerSystem : IInitializeSystem {

	private GameContext _context;

	public InitPlayerSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Initialize() {
		var entity = _context.CreateEntity();
		entity.AddAsset(AssetsEnum.Tank);
		entity.AddPosition(1, 1);
		entity.AddMove(0.5f, Vector2.zero);
		entity.isPlayerInput = true;
	}
}
