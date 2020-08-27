using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConditionType
{ 
    LessOrEqual = 1, //小于等于
    GreaterOrEqual = 2,//大于等于
    Equal = 3,//等于
}
public class SValueConditioner 
{
    private int groupId;
    private int Id;
    private ConditionType type = ConditionType.LessOrEqual;
    public bool Enable;

    private int _actionId;
    private bool _isOpen;
    public SValueConditioner(int pGroupId, int pId, ConditionType pType)
    {
        groupId = pGroupId;
        Id = pId;
        type = pType;
    }
    public void Open()
    {
        if (!Enable|| _isOpen)
            return;
       var group  = SValueWorld.Instance.GetGroup(groupId);
        if (group != null)
        {
            var sValue = group.GetSValue(Id);
            if (sValue != null)
            {
                _actionId = sValue.AddChangeAction(OnValueChange);
            }
        }
        _isOpen = true;
    }
    public void Close()
    {
        if (!Enable || !_isOpen)
            return;
        var group = SValueWorld.Instance.GetGroup(groupId);
        if (group != null)
        {
            var sValue = group.GetSValue(Id);
            if (sValue != null)
            {
                sValue.RemoveChangeAction(_actionId);
            }
        }
        _isOpen = false;
    }
    private void OnValueChange(float pValue)
    { 
        if()
    }

}
