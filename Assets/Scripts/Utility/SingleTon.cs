/* 
*********************************************************************
Copyright (C) 2021 The Company Name
Author:              第五枫咏
CreateTime:          2021/1/30
********************************************************************* 
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 单例基类
/// </summary>
public class SingleTon<T> where T : class
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)Activator.CreateInstance(typeof(T), true);
            }

            return instance;
        }
    }

}
