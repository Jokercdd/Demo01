using Godot;
using System;

public partial class Start : CanvasLayer
{

    private PackedScene otherScene;


    public override void _Ready()
	{
        otherScene = GD.Load<PackedScene>("res://Scenes/Newspapers.tscn");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void btnStart()
    {
        if (otherScene != null)
        {
            // 创建场景实例
            Node instance = otherScene.Instantiate();

            // 将实例添加到场景中
            GetTree().Root.AddChild(instance);
        }
    }
	public void btnQuit()
	{
        GetTree().Quit();
    }
}
