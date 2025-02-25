using Godot;
using System;

/* PlayerBaseST.cs 
 * ST = State
 * What the player's states inherit from.
 */
public abstract partial class PlayerBaseST : State<PlayerSM.PlayerState>
{
	protected readonly PlayerSM StateMachine;
	protected readonly Player Player;
	
	public PlayerBaseST(PlayerSM.PlayerState state, PlayerSM stateMachine) : base(state)
	{
		StateMachine = stateMachine;
		Player = StateMachine.Player;
	}

    public override void EnterState() {}
    public override void ExitState() {}
    public override void GetInput(InputEvent @event) {}
    public override void PhysicsProcess(double delta) {}
    public override void UnhandledInput(InputEvent @event) {}
	public override void UpdateState(double delta) {}

	// Update the Player's Animation
	protected abstract void UpdateAnimation();

	// Set the Player's Animation
	// Change the Current Animation
    /* TODO: Implement
	protected void SetAnimation(string animName)
	{
		Player.Sprite.Animation = animName;
		Player.Sprite.Play();
	}
    */
}
