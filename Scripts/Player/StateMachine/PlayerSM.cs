using Godot;
using System;

public partial class PlayerSM : StateMachine<PlayerSM.PlayerState>
{
	[Export] public Player Player {get; private set;}

	// States in which the player can be in
	public enum PlayerState
	{
		Normal,
		Bomb,
		Miss
	}

    public override void _Ready()
    {
		// Player starts in the "Normal" State.
		CurrentState = new PlayerNormalST (PlayerState.Normal, this);
		
		// Assign States to Keys
		States.Add(PlayerState.Normal, CurrentState);
		
		/* TODO: Implement
		States.Add(PlayerState.Bomb,  new PlayerBombST (PlayerState.Bomb, this));
		States.Add(PlayerState.Miss,  new PlayerMissST (PlayerState.Miss, this));
		*/
		
		// Enter the Initial State
		CurrentState.EnterState();
    }

	public String GetCurrentState() => CurrentState.StateKey.ToString();
}
