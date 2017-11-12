using Entitas;
using UnityEngine;

public class InputSystem : IExecuteSystem, ICleanupSystem {

	readonly InputContext _context;
	readonly IGroup<InputEntity> _fireInputs;

	public InputSystem(Contexts contexts) {
		_context = contexts.input;
		_context.SetDirectionInput(DirectionsEnum.None);
		_fireInputs = _context.GetGroup(InputMatcher.FireInput);
	}

	public void Execute() {
		_context.directionInput.value = DirectionsEnum.None;

		if (Input.GetKey(KeyCode.UpArrow)) {
			_context.directionInput.value = DirectionsEnum.Up;
		}

		if (Input.GetKey(KeyCode.DownArrow)) {
			_context.directionInput.value = DirectionsEnum.Down;
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			_context.directionInput.value = DirectionsEnum.Left;
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			_context.directionInput.value = DirectionsEnum.Right;
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			InputEntity entity = _context.CreateEntity();
			entity.isFireInput = true;
		}
	}

	public void Cleanup() {
		foreach (var input in _fireInputs.GetEntities()) {
			input.Destroy();
		}
	}
}