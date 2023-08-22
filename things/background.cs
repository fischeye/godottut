using Godot;
using System;

public partial class background : ParallaxBackground
{
	private float scrolling_speed = 50;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//ScrollOffset.X -= scrolling_speed * delta;
		//ScrollOffset[0];
		float scroll = scrolling_speed * (float)delta;
		float curOffset = ScrollOffset[0];

		Vector2 newScroll = new Vector2(curOffset - scroll, 0.0f);
		ScrollOffset = newScroll;
	}
}
