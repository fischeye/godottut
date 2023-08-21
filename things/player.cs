using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private AnimatedSprite2D sprites;
	private AnimationPlayer animation;

	public override void _Ready()
	{
		sprites = GetNode<AnimatedSprite2D>("sprites");
		//sprites.Play("idle");
		animation = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
			if (velocity.Y > 0) {
				animation.Play("jump");
			} else {
				animation.Play("fall");
			}
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		//GD.Print("Input (x,y): " + direction);
		//GD.Print("Velocity   : " + velocity.Y);
		if (direction[0] < 0) {
			sprites.FlipH = false;
		}
		if (direction[0] > 0) {
			sprites.FlipH = true;
		}
		if (direction[0] != 0)
		{
			velocity.X = direction.X * Speed;
			//sprites.Play("walk");
			if (velocity.Y == 0) {
				animation.Play("walk");
			}
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			//sprites.Play("idle");
			if (velocity.Y == 0) {
				animation.Play("idle");
			}
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
