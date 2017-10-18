using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    [SerializeField]
    private Text _redPlayerScore;

    [SerializeField]
    private Text _bluePlayerScore;

    [SerializeField]
    private Text _countdown;

    [SerializeField]
    private GameObject _pauseMenu;

    [SerializeField]
    private GameObject _quitButton;

    private void Awake() {
        Instance = this;
	}
	
	private void Update () {
        _redPlayerScore.text = GameManager.Instance.TeamRedScore.ToString();
        _bluePlayerScore.text = GameManager.Instance.TeamBlueScore.ToString();

        if (GameManager.Instance.Countdown > 0) {
            _countdown.text = GameManager.Instance.Countdown.ToString();
        }
        else {
            _countdown.text = string.Empty;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            _pauseMenu.gameObject.SetActive(!_pauseMenu.gameObject.activeInHierarchy);

            if (Application.platform == RuntimePlatform.WebGLPlayer) {
                _quitButton.SetActive(false);

            }

            InputManager.Instance.IsInputDisabled = _pauseMenu.gameObject.activeInHierarchy;
        }
	}

    public void OnResumePressed() {
        _pauseMenu.gameObject.SetActive(false);
    }

    public void OnBackToMainPressed() {
        SceneManager.LoadScene(Constants.MainMenuScene);
    }

    public void OnQuitPressed() {
        Application.Quit();
    }
}