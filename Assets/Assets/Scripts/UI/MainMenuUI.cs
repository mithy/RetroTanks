using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    public static MainMenuUI Instance;

    [SerializeField]
    private Button _quitButton;

    [SerializeField]
    private GameObject _modifiersWindow;

    private void Awake() {
        Instance = this;

        if (Application.platform == RuntimePlatform.WebGLPlayer) {
            _quitButton.gameObject.SetActive(false);
        }
    }

    private void Start() {
        ApplicationManager.Instance.ClearModifiers();
    }

    public void OnStartGamePressed() {
        SceneManager.LoadScene(Constants.GameScene);
    }

    public void OnModifiersPressed() {
        _modifiersWindow.SetActive(!_modifiersWindow.activeInHierarchy);
    }

    public void OnQuitPressed() {
        Application.Quit();
    }
	
}