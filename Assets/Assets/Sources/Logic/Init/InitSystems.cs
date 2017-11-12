﻿using Entitas;

public class InitSystems : Feature {

	public InitSystems(Contexts contexts) : base("Init Systems") {
		Add(new InitPlayerSystem(contexts));
	}

}