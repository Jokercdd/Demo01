using System.Collections.Generic;

public class StageConstant
{
    public static readonly Dictionary<int, List<int>> _stageDict = new Dictionary<int, List<int>>()
    {
        {1,new List<int>(){5,5,0,0 }},
        {2,new List<int>(){15,15,5,5}},
        {3,new List<int>(){25,25,15,15}}
    };
}
