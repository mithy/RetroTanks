using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages all the destructible objects in the game.
/// </summary>
public class PropsManager : MonoBehaviour {

    public static PropsManager Instance;

    [SerializeField]
    private Prop[] _propList;

    private List<Prop> _instantiatedProps = new List<Prop>();
    private List<Vector3> _usedPositions = new List<Vector3>();

    private void Awake() {
        Instance = this;
    }

    public void PopulateField() {
        int maximumProps = 
            ApplicationManager.Instance.IsModifierActive(ModifiersEnum.UltraTrees) ? Constants.MaximumUltraProps : Constants.MaximumProps;

        for (int i = 0; i < maximumProps; i++) {
            Prop p = Instantiate(_propList[Random.Range(0, _propList.Length)]);

            p.transform.SetParent(transform);
            p.transform.position = MapManager.Instance.GetRandomEmptyPosition(_usedPositions);

            _instantiatedProps.Add(p);
        }
    }

    public void ClearField() {
        for (int i = 0; i < _instantiatedProps.Count; i++) {
            if (_instantiatedProps[i] != null) {
                Destroy(_instantiatedProps[i].gameObject);
            }
        }

        _instantiatedProps.Clear();
        _usedPositions.Clear();
    }
}