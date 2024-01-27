using Godot;
using System;

public partial class Newspapers : CanvasLayer
{
    private PackedScene mainGame;
    private Sprite2D newsPapers;

    public override void _Ready()
	{
        mainGame = GD.Load<PackedScene>("res://Scenes/MainGame.tscn");
        newsPapers = GetNode<Sprite2D>("Newspaper");
    }

	public override void _Process(double delta)
	{
        if (Input.IsActionPressed("quit"))
            GetTree().Quit();
        if (Input.IsActionPressed("next"))
        {
            Node instance = mainGame.Instantiate();

            // 将实例添加到场景中
            GetTree().Root.AddChild(instance);
            GetTree().Root.RemoveChild(this);
        }
    }
}
