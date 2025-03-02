using Godot;
using System;

public partial class ScrollTest : Parallax2D
{
	[Export] private Vector2 cameraVelocity = new(0, 100);
	[Export] private TileMapLayer tileMap;
	public Rect2I UsedRect { private set; get;}
	public Camera2D Camera;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		UsedRect = tileMap.GetUsedRect();
		Camera = GetNode<Camera2D>("../Camera2D");
		SetCameraLimits();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 newOffset = GetScrollOffset() + cameraVelocity * (float) delta;
		SetScrollOffset(newOffset);
	}

	// Constrain the Camera to the borders of the tilemap, Allows for side scrolling
	private void SetCameraLimits()
	{
		Vector2I cellSize = tileMap.TileSet.TileSize;

		Camera.LimitLeft = UsedRect.Position.X * cellSize.X;
		Camera.LimitRight = UsedRect.End.X * cellSize.X;
		Camera.LimitTop = UsedRect.Position.Y * cellSize.Y;
		Camera.LimitBottom = UsedRect.End.Y * cellSize.Y;
	}

}
