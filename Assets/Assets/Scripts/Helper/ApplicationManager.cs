using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour {

    public static ApplicationManager Instance;

    public int GamePlays = 0;

    private List<ModifiersEnum> _activeModifiers = new List<ModifiersEnum>();

	private void Awake() {
        if (Instance == null) {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
	}

    public bool IsModifierActive(ModifiersEnum modifier) {
        return _activeModifiers.Contains(modifier);
    }

    public void TriggerModifier(ModifiersEnum modifier, bool status) {
        if (status == true && !_activeModifiers.Contains(modifier)) {
            _activeModifiers.Add(modifier);
        }

        if (status == false && _activeModifiers.Contains(modifier)) {
            _activeModifiers.Remove(modifier);
        }
    }

    public void ClearModifiers() {
        _activeModifiers.Clear();
    }
}