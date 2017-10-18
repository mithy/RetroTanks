using UnityEngine;

public class BulletManager : MonoBehaviour {

    public static BulletManager Instance;

    [SerializeField]
    private Bullet _blueBullet;

    [SerializeField]
    private Bullet _redBullet;

	private void Awake() {
        Instance = this;

        _blueBullet.gameObject.SetActive(false);
        _redBullet.gameObject.SetActive(false);
    }
	
	public void FireBullet(Vector3 position, Quaternion rotation, TeamsEnum team) {
        Bullet bullet = (team == TeamsEnum.TeamBlue ? _blueBullet : _redBullet);

        if (bullet.gameObject.activeInHierarchy == false) {
            bullet.gameObject.SetActive(true);
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
        }
    }
}