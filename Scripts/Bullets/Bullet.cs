using Godot;
using System;
using System.IO;

public partial class Bullet : Object
{
	public Rid ShapeID;
	public Vector2  MovementVector,
					Position;
	public float 	Lifetime,
				 	AnimationLifetime,
					Speed;
	public float	ImageOffset;
	public string	Layer;

    public static explicit operator Bullet(Variant v)
    {
        throw new NotImplementedException();
    }

}