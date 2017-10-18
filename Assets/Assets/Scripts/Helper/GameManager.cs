using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public int TeamBlueScore = 0;
    public int TeamRedScore = 0;

    public int Countdown = 0;

    [SerializeField]
    private TankCore _blueTank;

    [SerializeField]
    private TankCore _redTank;

    private void Awake() {
        Instance = this;
	}

    private void Start() {
        ApplicationManager.Instance.GamePlays++;
        StartCoroutine(RestartGame());
    }

    public IEnumerator RestartGame() {
        InputManager.Instance.IsInputDisabled = true;
        Countdown = Constants.CountdownMaximumTime;

        while (Countdown > 0) {
            yield return new WaitForSeconds(1.0f);
            Countdown--;
        }

        _blueTank.Initialize(MapManager.Instance.BluePlayerStart);
        _redTank.Initialize(MapManager.Instance.RedPlayerStart);

        PropsManager.Instance.ClearField();
        PropsManager.Instance.PopulateField();
        InputManager.Instance.IsInputDisabled = false;
    }

    public void RegisterVictory(TeamsEnum team) {
        switch (team) {
            case TeamsEnum.TeamBlue:
                TeamBlueScore++;
                break;

            case TeamsEnum.TeamRed:
                TeamRedScore++;
                break;
        }

        StartCoroutine(RestartGame());
    }
}