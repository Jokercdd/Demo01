using Godot;
using System;

public partial class Shop : Control
{
	private Button btnSure;
	private Button btnCancel;
	private Button btnNext;
	private Control next;
	private Control dialogue;

	public override void _Ready()
	{
        btnSure = GetNode<Button>("Dialogue/btnSure");
		btnCancel = GetNode<Button>("Dialogue/btnCancel");
        btnNext = GetNode<Button>("Next/btnNext");
        dialogue = GetNode<Control>("Dialogue");
        next = GetNode<Control>("Next");
	}

	public override void _Process(double delta)
	{

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
	}
}
