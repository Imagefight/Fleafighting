using Godot;
using System;

public partial class PlayerNormalST : PlayerBaseST
{
	public PlayerNormalST(PlayerSM.PlayerState state, PlayerSM stateMachine) : base(state, stateMachine) {}
	
    // Boolean to check if the player is willingly moving; used for animation
    private bool isMoving = false;

	public override void EnterState()   
    {
        // Return Player control when normal
        Player.ControlLock = Player.DirectionLock = false;
    }
    public override void ExitState() {}
    
	public override PlayerSM.PlayerState GetNextState() 
    {
        return StateKey;
    }

    public override void PhysicsProcess(double delta)
    {
        MovePlayer();
        CheckVelocity();
        
        Fire();
        AltFire();
    }

    // What will the player do when they press the fire button
    private void Fire()
    {
        if (Input.IsActionJustPressed("Fire"))
        {
            // Do Something
        }
    }

    // What will the player do when they press the Alt Fire Button
    private void AltFire()
    {
        if (Input.IsActionJustPressed("AltFire"))
        {
            // Do Something
        }
    }

    // Check if the player is WILLINGLY moving
    private void CheckVelocity() => isMoving = Player.Velocity != Vector2.Zero && !Player.ControlLock;

    private void MovePlayer()
    {
        if (Input.IsActionPressed("Focus")) 
            Player.Move(Player.FocusMagnitude);
        else 
            Player.Move();
    }

    protected override void UpdateAnimation() {}

}
