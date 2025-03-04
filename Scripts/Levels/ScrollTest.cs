using Godot;
using System;

public partial class ScrollTest : Parallax2D
{
	[Export] private Vector2 cameraVelocity = new(0, 100);
	[Export] private TileMapLayer tileMap;
	public Rect2I UsedRect { private set; get;}
	private Camera2D camera;
	private Player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		UsedRect = tileMap.GetUsedRect();
		camera = GetNode<Camera2D>("../Camera2D");
		player = GetNode<Player>("../Player");
		SetCameraLimits();
		SetPlayerLimits();
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

		camera.LimitLeft = UsedRect.Position.X * cellSize.X;
		camera.LimitRight = UsedRect.End.X * cellSize.X;
		camera.LimitTop = UsedRect.Position.Y * cellSize.Y;
		camera.LimitBottom = UsedRect.End.Y * cellSize.Y;
	}

	private void SetPlayerLimits()
	{
		Vector2I cellSize = tileMap.TileSet.TileSize;

		player.LimitLeft = UsedRect.Position.X * cellSize.X;
		player.LimitRight = UsedRect.End.X * cellSize.X;
		player.LimitTop = UsedRect.Position.Y * cellSize.Y;
		player.LimitBottom = UsedRect.End.Y * cellSize.Y;
	}
	
}