using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField]
	private Globals _globals;

	[SerializeField]
	private ProjectilePool _projectilePool;

    private Systems _systems;
	private Contexts _contexts;

    private void Start() {
		Random.InitState(321);

		_contexts = Contexts.sharedInstance;
		_contexts.game.SetGlobals(_globals);
		_contexts.game.SetProjectilePool(_projectilePool);

		_projectilePool.Initialize(_globals);

		_systems = CreateSystems(_contexts);
        _systems.Initialize();
	}

    private void Update() {
    	_systems.Execute();
		_systems.Cleanup();
    }

	private Systems CreateSystems(Contexts contexts) {
		return new Feature("Systems")
				// Initialize
				.Add(new InitSystems(contexts))

				// Input
				.Add(new InputSystem(contexts))

				// Gameplay
				.Add(new GameSystems(contexts))

				// Render
				.Add(new ViewSystems(contexts));
	}

}