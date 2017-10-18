using UnityEngine;
using UnityEngine.UI;

public class ModifierToggleUI : MonoBehaviour {

    [SerializeField]
    private ModifiersEnum type;

    private Color _initialColor;
    private Text _text;
    private Toggle _toggle;

	private void Start () {
        _toggle = GetComponent<Toggle>();
        _text = GetComponentInChildren<Text>();
        _initialColor = _text.color;

        ProcessModifier();
	}

    private void ProcessModifier() {
        bool isOk = false;

        switch (type) {
            case ModifiersEnum.UltraTrees:
                if (ApplicationManager.Instance.GamePlays > 1) {
                    isOk = true;
                }
                break;

            case ModifiersEnum.TankSpeedBoost:
                if (ApplicationManager.Instance.GamePlays > 2) {
                    isOk = true;
                }
                break;

            case ModifiersEnum.SecretLevel:
                if (ApplicationManager.Instance.GamePlays > 3) {
                    isOk = true;
                }
                break;
        }

        if (isOk) {
            _toggle.onValueChanged.AddListener(OnValueChanged);
        }
        else {
            _text.color = Color.red;
            _text.text = Constants.HiddenText;
            _toggle.interactable = false;
        }
    }
	
	private void OnValueChanged(bool newValue) {
        ApplicationManager.Instance.TriggerModifier(type, newValue);
	}
}