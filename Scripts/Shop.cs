using Godot;
using System;

public partial class Shop : Control
{
    private Button btnSure;
    private Button btnCancel;
    private Button btnNext;
    private Control next;
    private Control dialogue;
    private Control dialogue2;

    private Label txtScore;
    private Label txtPerfect;

    // 当前关卡ID
    public int nowID;
    // 当前关卡分数
    public int curScore;
    // 成绩
    public EGrade grade;
    // 是否触发彩蛋,true为触发
    public bool isOver = false;

    public override void _Ready()
    {
        btnSure = GetNode<Button>("Dialogue/btnSure");
        btnCancel = GetNode<Button>("Dialogue/btnCancel");
        btnNext = GetNode<Button>("Next/btnNext");
        dialogue = GetNode<Control>("Dialogue");
        dialogue2 = GetNode<Control>("Dialogue2");
        next = GetNode<Control>("Next");
        txtScore = GetNode<Label>("Next/txtScore");
        txtPerfect = GetNode<Label>("Next/txtPerfect");
        Init(3, 1, false);
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("quit"))
            GetTree().Quit();
    }

    // 对分数赋值
    public void Init(int score, int nowID, bool isOver)
    {
        this.curScore = score;
        this.nowID = nowID;
        this.isOver = isOver;
        var stageData = new StageConfigData(StageConstant._stageDict[nowID]);
        this.grade = StageConfigData.GetPingFen(score, stageData);

        // 触发彩蛋
        if (isOver)
        {
            dialogue2.Show();
        }
        else
        {
            dialogue.Show();
        }

    }

    /// <summary>
    /// 彩蛋确定
    /// </summary>
    public void OnPressBtnSure2()
    {
        dialogue2.Hide();
        next.Show();
        txtScore.Text = "评分：" + this.grade;
        if(curScore >= StageConstant._stageDict[nowID][0])
            txtPerfect.Text = "距离Perfect分数：0";
        else
            txtPerfect.Text = "距离Perfect分数：" + (StageConstant._stageDict[nowID][0] - curScore).ToString();
        GD.Print("现在的分数:" + curScore);
    }

    /// <summary>
    /// 彩蛋取消
    /// </summary>
    public void OnPressBtnCancel2()
    {
        dialogue2.Hide();
    }


    public void OnPressBtnSure()
    {
        dialogue.Hide();
        next.Show();
        txtScore.Text = "评分：" + this.grade;
        if (curScore >= StageConstant._stageDict[nowID][0])
            txtPerfect.Text = "距离Perfect分数：0";
        else
            txtPerfect.Text = "距离Perfect分数：" + (StageConstant._stageDict[nowID][0] - curScore).ToString();
        GD.Print("现在的分数:" + curScore);
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