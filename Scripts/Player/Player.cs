using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[ExportCategory("Player Attributes")]
	[Export] public AnimatedSprite2D Sprite {protected set; get;}
	[Export] protected int MoveSpeed;

	public bool  ControlLock   = false, // Player Controls are Locked
				 DirectionLock = false, // The Player's Direction is locked
				 Invincible    = false; // The Player is invincible
	public float Direction {get; set;} = 0; // Direction player is facing

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _PhysicsProcess(double delta)
    {
        MovePlayer();
    }

    // Move the player using a multiplier
    public void MovePlayer()
	{
		Velocity = 	Input.IsActionPressed("ShiftLT") ? // Is Left Shift Held?
					InputDirection() * (MoveSpeed/2) : // Half the Movement speed if true
					InputDirection() *  MoveSpeed;	   // Do normal Movement speed if not
		
		MoveAndSlide(); // Moves Player
	}

	// Update the player's Movement direction
	private Vector2 InputDirection()
	{
		Vector2 inputDirection = Input.GetVector("ArrowLT", "ArrowRT", "ArrowUP", "ArrowDN");

		/*
		if (!DirectionLock)
			Direction = Input.GetAxis("ArrowLT", "ArrowRT");
		
		if 		(Direction >  0) { Sprite.FlipH = true;  } 
		else if (Direction <= 0) { Sprite.FlipH = false; }
		*/

		return inputDirection;
	}
}
