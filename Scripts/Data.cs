using Godot;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

public partial class Data : Node
{

    private static Data instance;
    public static Data Instance => instance ?? (instance = new Data());

    // 存储关卡数据
    public Dictionary<int, Level> levelDic = new Dictionary<int, Level>();
    // 存储当前关卡对应部位的数量
    public List<Label> partList = new List<Label>();

    public Level level1;
    public Level level2;
    public Level level3;
    public Level level4;
    public Level level5;

    public Label headNum;
    public Label legNum;
    public Label wingNum;

    public Control headCtrl;
    public Control legCtrl;
    public Control wingCtrl;

    public int nowID = 1;

    public void InitLevel()
    {
        level1 = new Level();
        level1.type.Add(1);
        level1.type.Add(2);
        level1.type.Add(3);
        level1.time = 0;
        level1.id = 1;

        // 关卡2
        level2 = new Level();
        level2.type.Add(1);
        //level2.type.Add(2);
        level2.type.Add(3);
        level2.time = 0;
        level2.id = 2;

        // 关卡3
        level3 = new Level();
        level3.type.Add(1);
        level3.type.Add(2);
        //level3.type.Add(3);
        level3.time = 0;
        level3.id = 3;

        // 关卡4
        level4 = new Level();
        //level4.type.Add(1);
        level4.type.Add(2);
        level4.type.Add(3);
        level4.time = 0;
        level4.id = 4;
        // 关卡5

        // 关卡6
        // 关卡4
    }

    public void InitDic()
    {
        levelDic.Clear();
        levelDic.Add(1, level1);
        levelDic.Add(2, level2);
        levelDic.Add(3, level3);
        levelDic.Add(4, level4);
    }

    public override void _Ready()
    {
        Init();
        InitLevel();
        InitDic();
        InitOrder(1);
        int[] test = { 1, 100, 0 };
        InitNums(test);

        if (headCtrl != null)
            GD.Print(1);
        else
            GD.Print(2);
    }


    public void Init()
    {
        headNum = GetNode<Label>("Head/HeadNum");
        legNum = GetNode<Label>("Leg/LegNum");
        wingNum = GetNode<Label>("Wing/WingNum");

        headCtrl = GetNode<Control>("Head");
        legCtrl = GetNode<Control>("Leg");
        wingCtrl = GetNode<Control>("Wing");
    }

    public void InitOrder(int id)
    {
        if (nowID != id)
        {
            partList.Clear();
            GD.Print(headCtrl);
            legCtrl.Hide();
            wingCtrl.Hide();
            nowID = id;
        }

        Level nowLevel = levelDic[id];
        // 鹅头 1 head
        // 鹅翅膀 2 wing
        // 鹅掌 3 leg
        // 0,1,2
        // {1,0,1 }
        if (partList != null)
        {
            foreach (int type in nowLevel.type)
            {
                switch (type)
                {
                    case 1:
                        if (!partList.Contains(headNum))
                            partList.Add(headNum);
                        break;
                    case 2:
                        if (!partList.Contains(wingNum))
                            partList.Add(wingNum);
                        break;
                    case 3:
                        if (!partList.Contains(legNum))
                            partList.Add(legNum);
                        break;
                }
            }
        }
        if (partList.Contains(headNum))
            headCtrl.Show();
        else
            headCtrl.Hide();

        if (partList.Contains(wingNum))
            wingCtrl.Show();
        else
            wingCtrl.Hide();

        if (partList.Contains(legNum))
            legCtrl.Show();
        else
            legCtrl.Hide();
    }

    public void InitNums(int[] nums)
    {
        if (partList.Contains(headNum))
        {
            headCtrl.Show();
            headNum.Text = "× " + nums[0].ToString();
        }
        if (partList.Contains(wingNum))
        {
            wingCtrl.Show();
            wingNum.Text = "× " + nums[1].ToString();
        }
        if (partList.Contains(legNum))
        {
            legCtrl.Show();
            legNum.Text = "× " + nums[2].ToString();
        }
    }
}
