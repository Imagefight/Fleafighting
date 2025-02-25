using Godot;
using System;

public partial class Bullets : Node
{
	Vector2 movement_vectors; // Movement Direction
	Vector2 current_postion; // Current Position
	float lifetime = 0, // How long the bullet has existed
		  speed = 0, // Speed of the bullet (duh)
		  image_offset = 0, // Used for switching bullet textures (IDK if we will do this but putting the property here anyways)
		  animation_lifetime = 0; // Keeps track of the length since the last switch


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
