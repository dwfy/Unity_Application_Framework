/* 
*********************************************************************
Copyright (C) 2021 The Company Name
Author:              第五枫咏
CreateTime:          2021/1/30
********************************************************************* 
*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 对象池管理器
/// </summary>
public class PoolManager : SingleTon<PoolManager>
{
    /// <summary>
    /// 对象池字典
    /// </summary>
    private Dictionary<string, List<GameObject>> objectPool;

    /// <summary>
    /// 继承SingleTon且私有化无参构造，即相当于实现了单例
    /// </summary>
    private PoolManager()
    {
        //初始化对象池
        objectPool = new Dictionary<string, List<GameObject>>();
    }

    /// <summary>
    /// 从对象池中获取一个对象
    /// </summary>
    /// <param name="name">对象名称</param>
    /// <returns></returns>
    public void GetObj(string name, UnityAction<GameObject> action)
    {
        //判断池中是否有此对象
        if (objectPool.ContainsKey(name) && objectPool[name].Count > 0)
        {
            objectPool[name][0].SetActive(true);
            action(objectPool[name][0]);
            objectPool[name].RemoveAt(0);
        }
        else
        {
            ResLoadMgr.Instance.LoadResAsyn<GameObject>(name, (go) =>
            {
                go.name = name;
                go.SetActive(true);
                action(go);
            });
        }
    }

    /// <summary>
    /// 从对象池中获取一个对象
    /// </summary>
    /// <param name="name"></param>
    /// <param name="parent">放到的父物体</param>
    /// <returns></returns>
    public GameObject GetObj(string name, Transform parent)
    {
        GameObject obj = null;

        //判断池中是否有此对象
        if (objectPool.ContainsKey(name) && objectPool[name].Count > 0)
        {
            obj = objectPool[name][0];
            objectPool[name].RemoveAt(0);
        }
        else
        {
            obj = GameObject.Instantiate(Resources.Load<GameObject>(name),parent);
            obj.name = name;
            obj.transform.localPosition = parent.localPosition;
        }
        obj.SetActive(true);
        return obj;
    }

    /// <summary>
    /// 对象回收方法
    /// </summary>
    /// <param name="obj"></param>
    public void SetObj(GameObject obj)
    {
        if (obj == null)
        {
            return;
        }

        obj.SetActive(false);
        //如果池子中有当前对象的键，直接回收
        if (objectPool.ContainsKey(obj.name))
        {
            objectPool[obj.name].Add(obj);
        }
        //如果池子中没有当前对象的键，先建立池子再回收
        else
        {
            objectPool.Add(obj.name, new List<GameObject>(){obj});
        }
    }


    public void Clear()
    {
        objectPool.Clear();
    }
    
}
