using Godot;
using System;

public partial class Player : Area2D
{
    [Export]
    public int Speed { get; set; } = 400;

    public Vector2 ScreenSize;

    private PackedScene mirrorScene;
    private PackedScene partMoveScene;
    private PackedScene rotateScene;
    private PackedScene shopScene;

    private Node rotate;
    private Node partMove;
    private Node mirror;
    private Node shop;


    [Signal]
    public delegate void EnterEventHandler();


    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
        mirrorScene = GD.Load<PackedScene>("res://Scenes/WorkSpace/Mirror.tscn");
        partMoveScene = GD.Load<PackedScene>("res://Scenes/WorkSpace/PartMove.tscn");
        rotateScene = GD.Load<PackedScene>("res://Scenes/WorkSpace/Rotate.tscn");
        shopScene = GD.Load<PackedScene>("res://Scenes/WorkSpace/Shop.tscn");
    }

    public override void _Process(double delta)
    {
        Vector2 velocity = Vector2.Zero; // The player's movement vector.

        if (Input.IsActionPressed("move_right"))
            velocity.X += 1;
        if (Input.IsActionPressed("move_left"))
            velocity.X -= 1;
        if (Input.IsActionPressed("move_down"))
            velocity.Y += 1;
        if (Input.IsActionPressed("move_up"))
            velocity.Y -= 1;
        if (Input.IsActionPressed("quit"))
            GetTree().Quit();


        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
            // 动画
            //AnimatedSprite2D animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
            //animatedSprite2D.Play();
        }
        else
        {
            //animatedSprite2D.Stop();
        }

        Position += velocity * (float)delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
            y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
        );
    }

    public void EnterRotate(Node2D body)
    {
        GD.Print("EnterRotate");

        rotate = rotateScene.Instantiate();
        GetTree().Root.AddChild(rotate);
    }

    public void EnterMirror(Node2D body)
    {
        GD.Print("EnterMirror");
        mirror = mirrorScene.Instantiate();
        GetTree().Root.AddChild(mirror);
    }

    public void EnterPartMove(Node2D body)
    {
        GD.Print("EnterPartMove");
        partMove = partMoveScene.Instantiate();
        GetTree().Root.AddChild(partMove);
    }
    public void EnterShop(Node2D body)
    {
        GD.Print("EnterShop");
        shop = shopScene.Instantiate();
        GetTree().Root.GetChild(0).AddChild(shop);
    }

    /// <summary>
    /// 以下为退出时删除节点
    /// </summary>
    /// <param name="body"></param>
    public void ExitRotate(Node2D body)
    {
        GetTree().Root.RemoveChild(rotate);
    }

    public void ExitMirror(Node2D body)
    {
        GetTree().Root.RemoveChild(mirror);
    }

    public void ExitPartMove(Node2D body)
    {
        GetTree().Root.RemoveChild(partMove);
    }
    public void ExitrShop(Node2D body)
    {
        GetTree().Root.GetChild(0).RemoveChild(shop);
    }
}
