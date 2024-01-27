using Godot;
using System;

public partial class Start : CanvasLayer
{

    private PackedScene newsPapers;


    public override void _Ready()
	{
        newsPapers = GD.Load<PackedScene>("res://Scenes/Newspapers.tscn");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (Input.IsActionPressed("quit"))
            GetTree().Quit();
    }

    public void btnStart()
    {
        if (newsPapers != null)
        {
            // 创建场景实例
            Node instance = newsPapers.Instantiate();

            // 将实例添加到场景中
            GetTree().Root.AddChild(instance);
            GetTree().Root.RemoveChild(this);
        }
    }
	public void btnQuit()
	{
        GetTree().Quit();
    }
}
