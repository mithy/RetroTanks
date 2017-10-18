using UnityEngine;

public class TankCore : MonoBehaviour {

    [SerializeField]
    private Sprite _Anim1 = null;

    [SerializeField]
    private Sprite _Anim2 = null;

    [SerializeField]
    private TeamsEnum _team = TeamsEnum.TeamBlue;
    public TeamsEnum Team {
        get {
            return _team;
        }
    }

    private bool _isAlive;
    public bool IsAlive {
        get {
            return _isAlive;
        }
    }

    private GameObject _explosion;
    private Transform _rotation;

	private void Awake() {
        _explosion = transform.Find(Constants.ExplosionNode).gameObject;
        _explosion.SetActive(false);
        _rotation = transform.Find(Constants.TankRotationNode);

        if (_Anim1 != null) {
            _rotation.Find(Constants.TankFrameAnim1).GetComponent<SpriteRenderer>().sprite = _Anim1;
        }

        if (_Anim2 != null) {
            _rotation.Find(Constants.TankFrameAnim2).GetComponent<SpriteRenderer>().sprite = _Anim2;
        }
    }

    public void Initialize(Vector3 position) {
        _isAlive = true;
        _rotation.gameObject.SetActive(true);
        _explosion.SetActive(false);
        transform.position = position;
    }

    public void DestroyThis() {
        if (_isAlive == false) {
            return;
        }

        GameManager.Instance.RegisterVictory(_team == TeamsEnum.TeamBlue ? TeamsEnum.TeamRed : TeamsEnum.TeamBlue);
        _rotation.gameObject.SetActive(false);
        _explosion.SetActive(true);
        _isAlive = false;
    }
}