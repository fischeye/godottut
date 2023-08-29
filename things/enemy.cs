using Godot;
using System;
using System.Threading.Tasks;


public partial class enemy : CharacterBody2D
{
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    private AnimatedSprite2D enemySprites;
    private bool foundPlayer;

    private bool isDied;
    private long tickDead;

    public override void _Ready()
    {
        enemySprites = GetNode<AnimatedSprite2D>("enemySprites");
        isDied = false;
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

    public void _on_player_death_body_entered(Node2D body)
    {
        if (body.Name == "player") {
            isDied = true;
            //enemySprites.Play("death");
            tickDead = DateTime.UtcNow.Ticks + (TimeSpan.TicksPerMillisecond * 500);
            GD.Print("Enemy is dead!");
        }
    }
    
    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
        velocity.Y += gravity * (float)delta;

        if (foundPlayer && !isDied)
        {
            enemySprites.Play("attack");
        } else {
            enemySprites.Play("idle");
        }

        if (isDied)
        {
            enemySprites.Play("death");
            long curTick = DateTime.UtcNow.Ticks;
            if (curTick > tickDead)
            {
                QueueFree();
            }
        }

        Velocity = velocity;
        MoveAndSlide();
    }

}
