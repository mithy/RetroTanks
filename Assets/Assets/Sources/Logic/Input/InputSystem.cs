using Entitas;
using UnityEngine;
using System.Collections.Generic;

public class InputSystem : IExecuteSystem, ICleanupSystem {

	private readonly GameContext _gameContext;
	private readonly InputContext _inputContext;

	private readonly IGroup<GameEntity> _affectedEntities;
	private readonly IGroup<InputEntity> _fireInputs;

	public InputSystem(Contexts contexts) {
		_gameContext = contexts.game;
		_inputContext = contexts.input;

		_affectedEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerInput, GameMatcher.Move));
		_fireInputs = _inputContext.GetGroup(InputMatcher.FireInput);
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
			var move = entity.move;
			entity.ReplaceMove(move.speed, currentDirection, move.currentVelocity);
		}
	}

	private void ProcessFireInput() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			string playerUUID = _gameContext.globals.value.PlayerUUID;
				
			HashSet<GameEntity> entities = _gameContext.GetEntitiesWithIndexedEntity(playerUUID);
			GameEntity playerEntity = null;

			foreach (var e in entities) {
				playerEntity = e;
			}

			if (playerEntity != null) {
				InputEntity entity = _inputContext.CreateEntity();

				entity.AddFireInput(
					playerEntity.tankView.value.GetTurretPosition(),
					playerEntity.move.direction);
			}
		}
	}
}