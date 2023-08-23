using Godot;
using System;

public partial class Health : Label
{

    public override void _Process(double delta)
	{
        CharacterBody2D player = GetNode<CharacterBody2D>("../../player");
        GD.Print(player.Name);
        if (player.Name == "player") {
            GD.Print(player);
        }

        int playerHP = 100;
        Text = "HP: " + playerHP.ToString();
	}

}
