using UnityEngine;

public class Trigger : MonoBehaviour {

    [SerializeField]
    private TriggersEnum _type;
    public TriggersEnum Type {
        get {
            return _type;
        }
    }

    [SerializeField]
    private TriggersEnum _exitTrigger;
    public TriggersEnum ExitTrigger {
        get {
            return _exitTrigger;
        }
    }

    private Vector3 _exitPoint;
    public Vector3 ExitPoint {
        get {
            return _exitPoint;
        }
    }

    private void Awake() {
        _exitPoint = transform.Find(Constants.TriggerExitPointNode).position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        TankCore tank = other.gameObject.GetComponent<TankCore>();
        if (tank != null) {
            tank.transform.position = MapManager.Instance.GetTriggerExitPoint(_exitTrigger);
        }
    }
}