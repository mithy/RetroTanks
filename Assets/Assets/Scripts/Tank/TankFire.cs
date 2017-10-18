using UnityEngine;

public class TankFire : MonoBehaviour {

    private TankCore _core;
    private Transform _rotation;
    private Transform _bulletFire;

    private void Awake() {
        _core = GetComponent<TankCore>();
        _rotation = transform.Find(Constants.TankRotationNode);
        _bulletFire = _rotation.Find(Constants.BulletFireNode);
    }
	
	private void Update() {
        // Do not execute commands if the tank is dead.
        if (!_core.IsAlive) {
            return;
        }

        if (InputManager.Instance.IsFired(_core.Team)) {
            BulletManager.Instance.FireBullet(_bulletFire.position, _rotation.rotation, _core.Team);
        }
	}
}