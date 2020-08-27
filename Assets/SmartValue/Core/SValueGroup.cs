using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SValueGroup
{
    public int GroupId;
    private Dictionary<int,SValue> values;
    private int curSetId = 0;
    public SValueGroup(int pGroupId)
    {
        GroupId = pGroupId;
        values = new Dictionary<int, SValue>();
    }
    public SValue AddSValue(int pId,float pValue,float pTime)
    {
        SValue sValue = new SValue(pId, pValue, pTime);
        values.Add(pId, sValue);
        return sValue;
    }
    public SValue GetSValue(int pId)
    {
        if (values.ContainsKey(pId))
            return values[pId];
        return null;
    }
}
