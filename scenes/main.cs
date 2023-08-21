using Godot;
using System;
using System.Diagnostics;


public partial class main : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_exit_pressed()
	{
		GD.Print("Exit pressed");
		GetTree().Quit();
	}

	public void _on_start_pressed()
	{
		GD.Print("Start pressed");
		GetTree().ChangeSceneToFile("res://scenes/level_01.tscn");
	}
	
	public void _on_settings_pressed()
	{
		GD.Print("Settings pressed");
		GetTree().ChangeSceneToFile("res://scenes/settings.tscn");
	}
}
