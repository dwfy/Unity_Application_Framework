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
/// mono控制器，用于给没有继承monobehavior的类可以使用mono的相关生命周期
/// </summary>
public class MonoCtrl : MonoBehaviour
{
    private event UnityAction updateEvent;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        updateEvent?.Invoke();
    }

    public void AddUpdateEvent(UnityAction action)
    {
        updateEvent += action;
    }

    public void RemoveUpdateEvent(UnityAction action)
    {
        updateEvent -= action;
    }

}
