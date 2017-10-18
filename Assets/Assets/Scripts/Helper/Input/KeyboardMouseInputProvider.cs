using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to process normal input from Keyboard & Mouse.
/// </summary>
public class KeyboardMouseInputProvider : BaseInputProvider {

    public override void Initialize() {
        // Initialize starting directions.
        tankDirection.Add(TeamsEnum.TeamBlue, DirectionsEnum.None);
        tankDirection.Add(TeamsEnum.TeamRed, DirectionsEnum.None);

        // Set up the key mapping.
        blueTeamMapping.Add(ActionKeysEnum.Up, KeyCode.W);
        blueTeamMapping.Add(ActionKeysEnum.Down, KeyCode.S);
        blueTeamMapping.Add(ActionKeysEnum.Left, KeyCode.A);
        blueTeamMapping.Add(ActionKeysEnum.Right, KeyCode.D);
        blueTeamMapping.Add(ActionKeysEnum.Action, KeyCode.Space);

        redTeamMapping.Add(ActionKeysEnum.Up, KeyCode.UpArrow);
        redTeamMapping.Add(ActionKeysEnum.Down, KeyCode.DownArrow);
        redTeamMapping.Add(ActionKeysEnum.Left, KeyCode.LeftArrow);
        redTeamMapping.Add(ActionKeysEnum.Right, KeyCode.RightArrow);
        redTeamMapping.Add(ActionKeysEnum.Action, KeyCode.Return);
    }

    public override void Update() {
        ProcessInput(TeamsEnum.TeamBlue);
        ProcessInput(TeamsEnum.TeamRed);
    }

    public override void Reset() {
        tankDirection[TeamsEnum.TeamBlue] = DirectionsEnum.None;
        tankDirection[TeamsEnum.TeamRed] = DirectionsEnum.None;
    }

    protected override void ProcessInput(TeamsEnum team) {
        Dictionary<ActionKeysEnum, KeyCode> map = (team == TeamsEnum.TeamBlue ? blueTeamMapping : redTeamMapping);

        // Up.

        if (Input.GetKeyDown(map[ActionKeysEnum.Up])) {
            tankDirection[team] = DirectionsEnum.Up;
        }

        if (Input.GetKeyUp(map[ActionKeysEnum.Up]) && tankDirection[team] == DirectionsEnum.Up) {
            tankDirection[team] = DirectionsEnum.None;
        }

        // Down.

        if (Input.GetKeyDown(map[ActionKeysEnum.Down])) {
            tankDirection[team] = DirectionsEnum.Down;
        }

        if (Input.GetKeyUp(map[ActionKeysEnum.Down]) && tankDirection[team] == DirectionsEnum.Down) {
            tankDirection[team] = DirectionsEnum.None;
        }

        // Left.

        if (Input.GetKeyDown(map[ActionKeysEnum.Left])) {
            tankDirection[team] = DirectionsEnum.Left;
        }

        if (Input.GetKeyUp(map[ActionKeysEnum.Left]) && tankDirection[team] == DirectionsEnum.Left) {
            tankDirection[team] = DirectionsEnum.None;
        }

        // Right.

        if (Input.GetKeyDown(map[ActionKeysEnum.Right])) {
            tankDirection[team] = DirectionsEnum.Right;
        }

        if (Input.GetKeyUp(map[ActionKeysEnum.Right]) && tankDirection[team] == DirectionsEnum.Right) {
            tankDirection[team] = DirectionsEnum.None;
        }
    }

    public override DirectionsEnum GetCurrentDirection(TeamsEnum tankTeam) {
        return tankDirection[tankTeam];
    }

    public override bool IsFired(TeamsEnum team) {
        Dictionary<ActionKeysEnum, KeyCode> map = (team == TeamsEnum.TeamBlue ? blueTeamMapping : redTeamMapping);

        if (Input.GetKey(map[ActionKeysEnum.Action])) {
            return true;
        }

        return false;
    }
}
