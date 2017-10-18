using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour {

    public static MapManager Instance;

    [SerializeField]
    private Vector2 _size;
    public Vector2 Size {
        get {
            return _size;
        }
    }

    [SerializeField]
    private GameObject _normalLevel;

    [SerializeField]
    private GameObject _secretLevel;

    private Tilemap _tilemap;

    private Vector3 _bluePlayerStart;
    public Vector3 BluePlayerStart {
        get {
            return _bluePlayerStart;
        }
    }

    private Vector3 _redPlayerStart;
    public Vector3 RedPlayerStart {
        get {
            return _redPlayerStart;
        }
    }

    private Dictionary<TriggersEnum, Trigger> _triggers = new Dictionary<TriggersEnum, Trigger>();

    private int _maximumAttempts = 10;
    private int _propStartingRange = 1;

    private void Awake() {
        Instance = this;

        if (ApplicationManager.Instance.IsModifierActive(ModifiersEnum.SecretLevel)) {
            _normalLevel.SetActive(false);
            _secretLevel.SetActive(true);
        }

        _tilemap = GetComponentInChildren<Tilemap>();
        _bluePlayerStart = _tilemap.transform.Find(Constants.BlueTankStartNode).position;
        _redPlayerStart = _tilemap.transform.Find(Constants.RedTankStartNode).position;

        // Parse triggers.
        Trigger[] triggers = GetComponentsInChildren<Trigger>();
        foreach (Trigger trigger in triggers) {
            _triggers.Add(trigger.Type, trigger);
        }
    }

    public Vector3 GetTriggerExitPoint(TriggersEnum trigger) {
        if (_triggers.ContainsKey(trigger)) {
            return _triggers[trigger].ExitPoint;
        }

        return Vector3.zero;
    }

    public Vector3 GetRandomEmptyPosition(List<Vector3> usedPositions) {
        int maximumX = (int) _size.x - 1;
        int maximumY = (int) _size.y - 1;

        for (int i = 0; i < _maximumAttempts; i++) {
            Vector3Int newPosition = new Vector3Int(Random.Range(_propStartingRange, maximumX), Random.Range(_propStartingRange, maximumY), 0);
            TileBase tile = _tilemap.GetTile(newPosition);

            // If the tile is empty, a tree can be placed.
            Vector3 worldPosition = _tilemap.GetCellCenterWorld(newPosition);
            if (tile == null && !usedPositions.Contains(worldPosition)) {
                usedPositions.Add(worldPosition);
                return worldPosition;
            }
        }

        return Vector3.zero;
    }
}