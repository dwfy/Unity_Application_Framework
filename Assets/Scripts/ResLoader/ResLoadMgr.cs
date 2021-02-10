/* 
*********************************************************************
Copyright (C) 2021 The Company Name
Author:              第五枫咏
CreateTime:          2021/2/7
********************************************************************* 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 资源加载管理器
/// </summary>
public class ResLoadMgr : SingleTon<ResLoadMgr>
{
    private ResLoadMgr()
    {

    }

    /// <summary>
    /// 同步加载
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <param name="path">资源路径</param>
    /// <returns></returns>
    public T LoadRes<T>(string path) where T : Object
    {
        T res = Resources.Load<T>(path);
        if (res is GameObject)
        {
            return GameObject.Instantiate(res);
        }
        else
        {
            return res;
        }
    }

    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <param name="action"></param>
    public void LoadResAsyn<T>(string path, UnityAction<T> action) where T : Object
    {
        MonoManager.Instance.StartCoroutine(LoadResAsynCro(path, action));
    }

    IEnumerator LoadResAsynCro<T>(string path, UnityAction<T> action) where T : Object
    {
        ResourceRequest result = Resources.LoadAsync<T>(path);
        yield return result;

        if (result.asset is GameObject)
        {
            action(GameObject.Instantiate(result.asset) as T);
        }
        else
        {
            action(result.asset as T);
        }
    }

}
