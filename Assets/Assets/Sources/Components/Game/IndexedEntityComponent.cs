using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class IndexedEntityComponent : IComponent {
	[EntityIndex]
	public string uuid;
}