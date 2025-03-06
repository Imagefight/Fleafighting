using Godot;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;

public partial class BulletSpawner : Node2D
{
	[Export] private Image[] frames;
	[Export] private float imageChangeOffset;
	[Export] private float maxLifetime;

	private Marker2D origin;
	private Area2D	 sharedArea;

	// Only use for bullets pls
	private Godot.Collections.Array bullets;
	private Rect2 boundingBox;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	
	public override void _Draw()
	{
		Vector2I offset = frames[0].GetSize() / 2;
		
		for (int iterator = 0; iterator <= bullets.Count; iterator++)
		{
			Bullet bullet = (Bullet) bullets[iterator];

			if (bullet.AnimationLifetime >= imageChangeOffset)
			{
				bullet.ImageOffset += 1;
				bullet.AnimationLifetime = 0.0f;

				if (bullet.ImageOffset >= )
			}
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	// TODO: DEBLOAT THIS GARBAGE
    public override void _PhysicsProcess(double delta)
    {
        Transform2D usedTransform = new();
		Godot.Collections.Array destructQueue = new();

		for (int iterator = 0; iterator < bullets.Count; iterator++)
		{
			var varBullet = bullets[iterator];
			Bullet bullet = (Bullet) varBullet;
			
			bool surpassedLifetime = bullet.Lifetime >= maxLifetime,
				 outOfBounds =!boundingBox.HasPoint(bullet.Position);

			if ( outOfBounds || surpassedLifetime)
			{
				destructQueue.Add(varBullet);
				continue;
			}

			// Move bullet and collision
			Vector2 offset = bullet.MovementVector.Normalized() * bullet.Speed * (float) delta;
			
			bullet.Position += offset;
			usedTransform.Origin = bullet.Position;
			PhysicsServer2D.AreaSetShapeTransform(sharedArea.GetRid(), iterator, usedTransform);

			bullet.AnimationLifetime += (float) delta;
			bullet.Lifetime += (float) delta;
		}

		foreach (var varBullet in destructQueue)
		{
			Bullet bullet = (Bullet) varBullet;

			PhysicsServer2D.FreeRid(bullet.ShapeID);
			bullets.Remove(varBullet);
		}

		// Update();
    }

    // What the node does when leaving
    public override void _ExitTree()
    {
		// Deleting every bullet
        foreach (var bullet in bullets)
		{
			PhysicsServer2D.FreeRid( ( (Bullet) bullet ) .ShapeID );
		}

		bullets.Clear();	
    }
}
