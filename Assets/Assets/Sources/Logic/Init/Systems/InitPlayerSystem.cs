using Entitas;

public sealed class InitPlayerSystem : IInitializeSystem {

	private GameContext _context;

	public InitPlayerSystem(Contexts contexts) {
		_context = contexts.game;
	}

	public void Initialize() {
		var entity = _context.CreateEntity();
		entity.AddAsset(AssetsEnum.Tank);
		entity.AddPosition(0, 0);
		entity.AddMove(0.5f);
		entity.isPlayerInput = true;
	}
}
