using UnityEngine;

/// <summary>
/// Handles the tank's movement on the battlefield.
/// </summary>
public class TankMove : MonoBehaviour {

    private TankCore _core;
    private Transform _rotation;
    private Animator _animator;

	private void Awake() {
        _core = GetComponent<TankCore>();
        _rotation = transform.Find(Constants.TankRotationNode);
        _animator = GetComponentInChildren<Animator>();
	}
	
	private void Update() {
        // Do not execute commands if the tank is dead.
        if (!_core.IsAlive) {
            return;
        }

        DirectionsEnum currentDirection = InputManager.Instance.GetCurrentDirection(_core.Team);
        Vector3 direction = Vector3.zero;

        switch (currentDirection) {
            case DirectionsEnum.Up:
                direction = new Vector3(0, 1, 0);
                _rotation.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
                break;

            case DirectionsEnum.Down:
                direction = new Vector3(0, -1, 0);
                _rotation.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;

            case DirectionsEnum.Left:
                direction = new Vector3(-1, 0, 0);
                _rotation.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;

            case DirectionsEnum.Right:
                direction = new Vector3(1, 0, 0);
                _rotation.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                break;
        }

        if (direction == Vector3.zero) {
            _animator.StartPlayback();
        }
        else {
            _animator.StopPlayback();
        }

        float speed = ApplicationManager.Instance.IsModifierActive(ModifiersEnum.TankSpeedBoost) ? Constants.TankSpeedExtreme : Constants.TankSpeed; 

        // Move the tank in the desired direction tanking also care about frames per second.
        transform.Translate(direction * speed * Time.deltaTime);
    }
}