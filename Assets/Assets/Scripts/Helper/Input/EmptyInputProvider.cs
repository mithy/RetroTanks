/// <summary>
/// Used to block inputs.
/// </summary>
public class EmptyInputProvider : BaseInputProvider {
    public override void Initialize() {
        // Nothing.
    }

    public override void Update() {
        // Nothing.
    }

    protected override void ProcessInput(TeamsEnum team) {
        // Nothing.
    }

    public override void Reset() {
        // Nothing.
    }

    public override DirectionsEnum GetCurrentDirection(TeamsEnum tankTeam) {
        return DirectionsEnum.None;
    }

    public override bool IsFired(TeamsEnum team) {
        return false;
    }
}