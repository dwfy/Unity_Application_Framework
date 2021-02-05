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
/// mono管理器
/// </summary>
public class MonoManager : SingleTon<MonoManager>
{
    private GameObject obj = null;
    private MonoCtrl mono = null;
    private MonoManager()
    {
        obj = new GameObject("MonoBehavior");
        mono = obj.AddComponent<MonoCtrl>();
    }
    /// <summary>
    /// 添加帧更新事件
    /// </summary>
    /// <param name="action"></param>
    public void AddUpdateEvent(UnityAction action)
    {
        mono.AddUpdateEvent(action);
    }

    /// <summary>
    /// 移除帧更新事件
    /// </summary>
    /// <param name="action"></param>
    public void RemoveUpdateEvent(UnityAction action)
    {
        mono.RemoveUpdateEvent(action);
    }

    /// <summary>
    /// 开启协程
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public Coroutine StartCoroutine(IEnumerator method)
    {
        return StartCoroutine(method);
    }

    public Coroutine StartCoroutine(string methodName)
    {
        return mono.StartCoroutine(methodName);
    }

    public Coroutine StartCoroutine(string methodName, object value)
    {
        return mono.StartCoroutine(methodName, value);
    }
}
