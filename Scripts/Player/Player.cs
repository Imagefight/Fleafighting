using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[ExportCategory("Player Attributes")]
	[Export] public AnimatedSprite2D Sprite {protected set; get;}
	[Export] protected float MoveSpeed; 
	[Export] public float FocusMagnitude;
	[Export] private PlayerSM stateMachine;

	[Export] public int LimitLeft, LimitRight, LimitBottom, LimitTop;

	public bool  ControlLock   = false, // Player Controls are Locked
				 DirectionLock = false, // The Player's Direction is locked
				 Invincible    = false; // The Player is invincible
	public float Direction {get; set;} = 0; // Direction player is facing

	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {}

    public override void _UnhandledInput(InputEvent @event)
    {
		if (!ControlLock)
			stateMachine._Input(@event);
    }

    public override void _PhysicsProcess(double delta){}

    // Move the player
    public void Move()
	{
		Move(1);
	}

	// Move the player by a certain magnitude
	public void Move(float magnitude)
	{
		Velocity = 	InputDirection() * (MoveSpeed * magnitude);
		MoveAndSlide(); // Moves Player
		ClampPlayer();
	}

	// Update the player's Movement direction
	private Vector2 InputDirection()
	{
		Vector2 inputDirection = Input.GetVector("MoveLT", "MoveRT", "MoveUP", "MoveDN");

		/*
		if (!DirectionLock)
			Direction = Input.GetAxis("ArrowLT", "ArrowRT");
		
		if 		(Direction >  0) { Sprite.FlipH = true;  } 
		else if (Direction <= 0) { Sprite.FlipH = false; }
		*/

		return inputDirection;
	}

	private void ClampPlayer()
	{
		Position = new Vector2(
		Mathf.Clamp(Position.X, LimitLeft, LimitRight),
		Mathf.Clamp(Position.Y, LimitTop,  LimitBottom)
		);
	}
}
