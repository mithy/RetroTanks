using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input, Unique]
public class DirectionInputComponent : IComponent {
	public DirectionsEnum value;
}