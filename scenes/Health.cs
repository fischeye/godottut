using Godot;
using System;

public partial class Health : Label
{

    public override void _Process(double delta)
	{
        CharacterBody2D player = GetNode<CharacterBody2D>("../../player");
        // cast Class for whatever reason???
        int playerHP = ((player)player).health;
        Text = "HP: " + playerHP.ToString();
	}

}
