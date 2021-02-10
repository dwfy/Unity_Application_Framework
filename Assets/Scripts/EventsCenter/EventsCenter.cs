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
        eventsDic = new Dictionary<string, IEventInfo>();
    }

    private Dictionary<string, IEventInfo> eventsDic;

    /// <summary>
    /// 添加监听
    /// </summary>
    /// <param name="eventname"></param>
    /// <param name="action"></param>
    public void AddListener<T>(string eventname, UnityAction<T> action)
    {
        if (eventsDic.ContainsKey(eventname))
        {
            (eventsDic[eventname] as EventInfo<T>).actions += action;
        }
        else
        {
            eventsDic.Add(eventname, new EventInfo<T>(action));
        }
    }

    public void AddListener(string name, UnityAction action)
    {
        if (eventsDic.ContainsKey(name))
        {
            (eventsDic[name] as EventInfo).actions += action;
        }
        else
        {
            eventsDic.Add(name, new EventInfo(action));
        }
    }

    /// <summary>
    /// 移除监听
    /// </summary>
    /// <param name="eventname"></param>
    /// <param name="action"></param>
    public void RemoveListener<T>(string eventname, UnityAction<T> action)
    {
        if (eventsDic.ContainsKey(eventname))
        {
            (eventsDic[eventname] as EventInfo<T>).actions -= action;
        }
    }

    public void RemoveListener(string name, UnityAction action)
    {
        if (eventsDic.ContainsKey(name))
        {
            (eventsDic[name] as EventInfo).actions -= action;
        }
    }

    /// <summary>
    /// 触发
    /// </summary>
    /// <param name="name"></param>
    /// <param name="obj"></param>
    public void EventTrigger<T>(string name, T obj)
    {
        if (eventsDic.ContainsKey(name))
        {
            (eventsDic[name] as EventInfo<T>).actions?.Invoke(obj);
        }
    }

    public void EventTrigger(string name)
    {
        if (eventsDic.ContainsKey(name))
        {
            (eventsDic[name] as EventInfo).actions?.Invoke();
        }
    }

    /// <summary>
    /// 清空事件
    /// </summary>
    public void Clear()
    {
        eventsDic.Clear();
    }
    
}
