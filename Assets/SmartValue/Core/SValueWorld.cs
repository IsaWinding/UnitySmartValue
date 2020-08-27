using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SValueWorld 
{
    private static SValueWorld instance;
    public static SValueWorld Instance { get { if (instance == null) instance = new SValueWorld(); return instance;  } }

    private int SetValue;

    private Dictionary<int, SValueGroup> groups = new Dictionary<int, SValueGroup>();

    public int AddGroup()
    {
        SetValue++;
        SValueGroup group = new SValueGroup(SetValue);
        groups.Add(SetValue, group);
        return SetValue;
    }
    public SValueGroup GetGroup(int pGroupId)
    {
        if (groups.ContainsKey(pGroupId))
            return groups[pGroupId];
        return null;
    }

}
