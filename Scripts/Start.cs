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
	}

    public void btnStart()
    {
        if (newsPapers != null)
        {
            GD.Print("aa");

            // 创建场景实例
            Newspapers instance = newsPapers.Instantiate<Newspapers>();

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
