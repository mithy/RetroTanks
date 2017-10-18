using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInputProvider  {

    protected Dictionary<TeamsEnum, DirectionsEnum> tankDirection = new Dictionary<TeamsEnum, DirectionsEnum>();

    protected Dictionary<ActionKeysEnum, KeyCode> blueTeamMapping = new Dictionary<ActionKeysEnum, KeyCode>();
    protected Dictionary<ActionKeysEnum, KeyCode> redTeamMapping = new Dictionary<ActionKeysEnum, KeyCode>();

    public abstract void Initialize();

    public abstract void Update();

    public abstract void Reset();

    protected abstract void ProcessInput(TeamsEnum team);

    public abstract DirectionsEnum GetCurrentDirection(TeamsEnum tankTeam);

    public abstract bool IsFired(TeamsEnum team);
}