using Godot;
using System;

public partial class Newspapers : CanvasLayer
{
    private PackedScene mainGame;
    private Sprite2D newsPapers;
    private Texture2D newTexture;

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

    // 更新报纸
    public void UpdateNewsPaper(int id)
    {
        string res = "res://Resources/NewsPaper/" + id + ".png";
        newTexture = GD.Load<Texture2D>(res);
        newsPapers.Texture = newTexture;
    }
}
