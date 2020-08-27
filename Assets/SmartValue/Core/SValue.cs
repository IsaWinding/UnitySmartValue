using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SValue 
{
    public int Id;
    public float Value;
    public float DeltaValue;
    public float Time;
    private int ValueId;
    private int curActionId;
    private Dictionary<int, System.Action<float>> map;
    public SValue(int pId,float pValue,float pTime = 0)
    {
        Id = pId;
        Value = pValue;
        Time = pTime;
        map = new Dictionary<int, System.Action<float>>();
    }

    
    public int AddChangeAction(System.Action<float> pAction)
    {
        curActionId++;
        map.Add(curActionId, pAction);
        return curActionId;
    }
    public void RemoveChangeAction(int pActionId)
    {
        if (map.ContainsKey(pActionId))
        {
            map.Remove(pActionId);
        }
    }
    public float GetValue(float pTime)
    {
        return Value + (pTime - DeltaValue) * DeltaValue;
    }
    public float SetValue(float pValue,float pTime,float pDeltaTime = 0 )
    {
        Value = pValue;
        Time = pTime;
        DeltaValue = pDeltaTime;
        OnValueChange(pTime);
        return GetValue(pTime);
    }
    public float SetValueToTarget(float pValue, float pTime)
    {
        return SetValue(pValue, pTime);
    }
    public float AddValue(float pAddValue, float pTime)
    {
        Value += pAddValue;
        OnValueChange(pTime);
        return GetValue(pTime);
    }
    public float AddDeltaValue(float pAddDeltaValue, float pTime)
    {
        Value = GetValue(pTime);
        DeltaValue += pAddDeltaValue;
        Time = pTime;
        OnValueChange(pTime);
        return Value;
    }
    private void OnValueChange(float pTime)
    {
        ValueId += ValueId;
        float _value = GetValue(pTime);
        foreach (var temp in map)
        {
            temp.Value.Invoke(_value);
        }
    }
}
