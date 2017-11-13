using Entitas;

[Game]
public class TankViewComponent : IComponent {
	public TankView value;
	public DirectionsEnum currentDirection;
}