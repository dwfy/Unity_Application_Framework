/* 
*********************************************************************
Copyright (C) 2021 The Company Name
Author:              第五枫咏
CreateTime:          2021/2/10
********************************************************************* 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 事件中心事件信息，这么拆是为了避免频繁的装箱和拆箱
/// </summary>
/// <typeparam name="T"></typeparam>
public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}

public class EventInfo : IEventInfo
{
    public UnityAction actions;

    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}
