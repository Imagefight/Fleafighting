using Godot;
using System;

public partial class Bullets : Node
{

	public Rid ShapeId; //ID used to communicate with the physics server
	public Vector2 MovementVector; // Movement Direction
	public Vector2 CurrentPostion; // Current Position
	public float Lifetime = 0, // How long the bullet has existed
		  		 Speed = 0, // Speed of the bullet (duh)
		  		 ImageOffset = 0, // Used for switching bullet textures (IDK if we will do this but putting the property here anyways)
		  		 AnimationLifetime = 0; // Keeps track of the length since the last switch

	public void RegisterBullet(Vector2 Movement, float Speed = 200) //Bullet Constructor (WIP)
	{
		Bullets Bullet = new Bullets();
		Bullet.MovementVector = Movement;
		Bullet.Speed = Speed;

	}


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
