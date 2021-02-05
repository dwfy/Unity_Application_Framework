/* 
*********************************************************************
Copyright (C) 2021 The Company Name
Author:              第五枫咏
CreateTime:          2021/1/31
********************************************************************* 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 事件中心
/// </summary>
public class EventsCenter : SingleTon<EventsCenter>
{
    private EventsCenter()
    {
        eventsDic = new Dictionary<string, UnityAction<object>>();
    }

    private Dictionary<string, UnityAction<object>> eventsDic;

    /// <summary>
    /// 添加监听
    /// </summary>
    /// <param name="eventname"></param>
    /// <param name="action"></param>
    public void AddListener(string eventname, UnityAction<object> action)
    {
        if (eventsDic.ContainsKey(eventname))
        {
            eventsDic[eventname] += action;
        }
        else
        {
            eventsDic.Add(eventname, action);
        }
    }

    /// <summary>
    /// 移除监听
    /// </summary>
    /// <param name="eventname"></param>
    /// <param name="action"></param>
    public void RemoveListener(string eventname, UnityAction<object> action)
    {
        if (eventsDic.ContainsKey(eventname))
        {
            eventsDic[eventname] -= action;
        }
    }

    /// <summary>
    /// 触发
    /// </summary>
    /// <param name="name"></param>
    /// <param name="obj"></param>
    public void EventTrigger(string name, object obj)
    {
        eventsDic[name]?.Invoke(obj);
    }

    /// <summary>
    /// 清空事件
    /// </summary>
    public void Clear()
    {
        eventsDic.Clear();
    }
    
}
