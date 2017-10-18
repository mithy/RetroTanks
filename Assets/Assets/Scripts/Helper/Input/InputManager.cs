using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the input from both of the players.
/// </summary>
public class InputManager : MonoBehaviour {

    public static InputManager Instance;

    private bool _isInputDisabled;
    public bool IsInputDisabled {
        get {
            return _isInputDisabled;
        }
        set {
            if (value == true) {
                _currentInputProvider = _inputProviders[InputProvidersEnum.None];
            }
            else {
                _currentInputProvider = _inputProviders[InputProvidersEnum.KeyboardMouse];
            }

            _currentInputProvider.Reset();
            _isInputDisabled = value;
        }
    }

    private Dictionary<InputProvidersEnum, BaseInputProvider> _inputProviders = new Dictionary<InputProvidersEnum, BaseInputProvider>();
    private BaseInputProvider _currentInputProvider;

    private void Awake() {
        Instance = this;
        Initialize();
    }

    private void Initialize() {
        _inputProviders.Add(InputProvidersEnum.None, new EmptyInputProvider());
        _inputProviders.Add(InputProvidersEnum.KeyboardMouse, new KeyboardMouseInputProvider());

        // Initialize the input providers.
        foreach (KeyValuePair<InputProvidersEnum, BaseInputProvider> input in _inputProviders) {
            input.Value.Initialize();
        }

        if (_inputProviders.ContainsKey(InputProvidersEnum.KeyboardMouse)) {
            _currentInputProvider = _inputProviders[InputProvidersEnum.KeyboardMouse];
        }
    }

    private void Update() {
        _currentInputProvider.Update();
    }    

    public DirectionsEnum GetCurrentDirection(TeamsEnum team) {
        return _currentInputProvider.GetCurrentDirection(team);   
    }

    public bool IsFired(TeamsEnum team) {
        return _currentInputProvider.IsFired(team);
    }
}