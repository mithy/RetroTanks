using Entitas;

public class GameSystems : Feature {
	public GameSystems(Contexts contexts) : base("Game Systems") {
		Add(new MoveSystem(contexts));
		Add(new FireProjectileSystem(contexts));
		Add(new ProcessProjectileHitSystem(contexts));
	}
}