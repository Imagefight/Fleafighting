using Godot;
using System;

/* WindowManager.cs [DEPRICATED]
 * Used to keep aspect ratio when resizing window
 * TODO: Breaks at certain percentages, fix later
 */
public partial class WindowManager : Node
{
	private Vector2I defaultSize, currentSize, previousSize;
	private bool ignoreY = false,
				 ignoreX = false;
	private Vector2 scale;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetSize();
		defaultSize = currentSize;
		
		GetScale();
		UpdatePreviousSize();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GetSize();
		GetScale();
		GD.Print(scale);
		GD.Print(defaultSize);

		Scale();

		Reposition();
		Resize();

		UpdatePreviousSize();
	}

	// Prevents title bar from being moved offscreen
	private void Reposition()
	{
		if (DisplayServer.WindowGetPosition().Y < 0)
			DisplayServer.WindowSetPosition(new Vector2I(DisplayServer.WindowGetPosition().X, 0));
	}
	// Prevent Size from being too small
	private void Resize()
	{
		if (currentSize < defaultSize / 4)
		{
			DisplayServer.WindowSetSize(defaultSize / 4);
		}
	}

	// Scale the Y axis
	private void ScaleY()
	{
		// If the window is being resized by X and not Y; 
		if (currentSize.X != previousSize.X && !ignoreX)
		{
			// Scale Y axis by same factor as X
			SetSize(currentSize.X, (int) (defaultSize.Y * scale.X));
			ignoreY = true;
		} 
		// Stop ignoring X
		else if (currentSize.X == previousSize.X && ignoreX) 
			ignoreX = false;
	}

	// Scale the X axis
	private void ScaleX()
	{
		// If the window is being resized by Y and not X; 
		if (currentSize.Y != previousSize.Y && !ignoreY)
		{
			// Scale X axis by same factor as Y
			SetSize( (int) (defaultSize.X * scale.Y), currentSize.Y );
			ignoreX = true;
		} 
		// Stop ignoring Y
		else if (currentSize.Y == previousSize.Y && ignoreY) 
			ignoreY = false;
	}

	private void Scale() 
	{
		ScaleX(); 
		ScaleY();
	}

	private void GetScale() => scale = ( (Vector2) currentSize ) / ( (Vector2) defaultSize ) ;
	private void GetSize() => currentSize = DisplayServer.WindowGetSize();
	private void SetSize(int width, int height) => DisplayServer.WindowSetSize(new Vector2I(width, height));
	private void UpdatePreviousSize() => previousSize = currentSize;
}
