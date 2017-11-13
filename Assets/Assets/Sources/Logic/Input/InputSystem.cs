using Entitas;
using UnityEngine;

public class InputSystem : IExecuteSystem, ICleanupSystem {

	private readonly InputContext _context;
	private readonly IGroup<GameEntity> _affectedEntities;
	private readonly IGroup<InputEntity> _fireInputs;

	public InputSystem(Contexts contexts) {
		_context = contexts.input;

		_affectedEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerInput, GameMatcher.TankView));
		_fireInputs = _context.GetGroup(InputMatcher.FireInput);
	}

	public void Execute() {
		ProcessDirectionInput();
		ProcessFireInput();
	}

	public void Cleanup() {
		foreach (var input in _fireInputs.GetEntities()) {
			input.Destroy();
		}
	}

	private void ProcessDirectionInput() {
		DirectionsEnum currentDirection = DirectionsEnum.None;

		if (Input.GetKey(KeyCode.UpArrow)) {
			currentDirection = DirectionsEnum.Up;
		}

		if (Input.GetKey(KeyCode.DownArrow)) {
			currentDirection = DirectionsEnum.Down;
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			currentDirection = DirectionsEnum.Left;
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			currentDirection = DirectionsEnum.Right;
		}

		foreach (var entity in _affectedEntities) {
			entity.ReplaceTankView(entity.tankView.value, currentDirection);
		}
	}

	private void ProcessFireInput() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			InputEntity entity = _context.CreateEntity();
			entity.isFireInput = true;
		}
	}
}