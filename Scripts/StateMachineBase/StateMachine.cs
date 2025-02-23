using Godot;
using System;
using System.Collections.Generic;

// Common State Machine for dictating entity behavior
public abstract partial class StateMachine<EState> : Node where EState : Enum
{
	protected Dictionary<EState, State<EState>> States = new Dictionary<EState, State<EState>>();
	protected State<EState> CurrentState;

	protected bool IsTransitioningState = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CurrentState.EnterState();
		RequestReady();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		EState nextStateKey = CurrentState.GetNextState();
		if (!IsTransitioningState && nextStateKey.Equals(CurrentState.StateKey)) {CurrentState.UpdateState(delta);}
		else if (!IsTransitioningState) {TransitionToState(nextStateKey);}
		CurrentState.UpdateState(delta);
	}

	public void TransitionToState(EState statekey)
	{
		// Leave Current State
		IsTransitioningState = true;
		CurrentState.ExitState();

		// Go to a New One
		CurrentState = States[statekey];
		CurrentState.EnterState();

		// All Clear
		IsTransitioningState = false;
	}

    public override void _PhysicsProcess(double delta)
    {
        CurrentState.PhysicsProcess(delta);
    }

    public override void _Input(InputEvent @event)
    {
		CurrentState.GetInput(@event);
    }

}
