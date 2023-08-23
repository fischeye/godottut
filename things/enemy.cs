using Godot;
using System;

public partial class enemy : CharacterBody2D
{
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    private AnimatedSprite2D enemySprites;
    private bool foundPlayer;

    public override void _Ready()
    {
        enemySprites = GetNode<AnimatedSprite2D>("enemySprites");
    }

    public void _on_player_detection_body_entered(Node2D body)
    {
        if (body.Name == "player") {
            GD.Print("Attack!");
            foundPlayer = true;
        }
    }

    public void _on_player_detection_body_exited(Node2D body)
    {
        if (body.Name == "player") {
            GD.Print("Where is he?!");
            foundPlayer = false;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
        velocity.Y += gravity * (float)delta;

        if (foundPlayer)
        {
            enemySprites.Play("attack");
        } else {
            enemySprites.Play("idle");
        }

        Velocity = velocity;
        MoveAndSlide();
    }

}
