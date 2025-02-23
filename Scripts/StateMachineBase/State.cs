using Godot;
using System;
using System.Collections.Generic;

public abstract class State<EState> where EState : Enum
{
	public State(EState key){
		StateKey = key;
	}

	public EState StateKey {get; private set;}
	public bool IsLoaded = false;

	public abstract void EnterState(); // Call state logic on entrace
	public abstract void ExitState();  // Cleanup after a state leaves
	public abstract void UpdateState(double delta); // Call Current State Logic Once per Frame
	public abstract EState GetNextState();
	public abstract void PhysicsProcess(double delta);
	public abstract void GetInput(InputEvent @event); // Get the Input First
	public abstract void UnhandledInput(InputEvent @event); // Handling Unprocessed Inputs (Gets the Leftovers)
}
