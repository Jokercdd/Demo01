using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class StageConfigData
{
    public int minPerfect;
    public int minWell;
    public int maxwell;
    public int maxEhuh;

    public StageConfigData()
    {

    }

    public StageConfigData(int minPerfect, int maxwell, int minWell, int maxEhuh)
    {
        this.minPerfect = minPerfect;
        this.minWell = minWell;
        this.maxwell = maxwell;
        this.maxEhuh = maxEhuh;
    }

    public StageConfigData(List<int> stageCfgs)
    {
        this.minPerfect = stageCfgs[0];
        this.minWell = stageCfgs[1];
        this.maxwell = stageCfgs[2];
        this.maxEhuh = stageCfgs[3];
    }

    public static EGrade GetPingFen(int curScore, StageConfigData data)
    {
        if (curScore > data.minPerfect)
        {
            return EGrade.genius;
        }
        else if (curScore < data.minWell && curScore > data.maxwell)
        {
            return EGrade.nice;
        }
        else if (curScore < data.maxEhuh)
        {
            return EGrade.bruh;
        }
        else
        {
            GD.PrintErr("有问题");
            return EGrade.None;
        }
    }
}

public enum EGrade
{
    None = 0,
    genius = 1,
    nice = 2,
    bruh = 3,
}


