using Godot;
using System;

public partial class Shop : Control
{
    private Button btnSure;
    private Button btnCancel;
    private Button btnNext;
    private Control next;
    private Control dialogue;

    // 当前关卡ID
    private int nowID;

    public override void _Ready()
    {
        btnSure = GetNode<Button>("Dialogue/btnSure");
        btnCancel = GetNode<Button>("Dialogue/btnCancel");
        btnNext = GetNode<Button>("Next/btnNext");
        dialogue = GetNode<Control>("Dialogue");
        next = GetNode<Control>("Next");
        nowID = Data.Instance.nowID;
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("quit"))
            GetTree().Quit();
    }

    public void OnPressBtnSure()
    {
        dialogue.Hide();
        next.Show();
    }

    public void OnPressBtnCancel()
    {
        dialogue.Hide();
    }

    public void OnPressBtnNext()
    {
        // 下一关
        int id = nowID + 1;
        //Data.Instance.Init();
        Data.Instance.InitLevel();
        Data.Instance.InitDic();
        Data.Instance.InitOrder(id);
        QueueFree();
    }
}