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

public class TestPool : MonoBehaviour
{
    void Start()
    {
        EventsCenter.Instance.AddListener("CreateCube", CreatCube);
//        MonoManager.Instance.AddUpdateEvent(Print);
//        StartCoroutine("Test01");
        StartCoroutine(Test03("1","2"));
    }

    //    void Update()
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            EventsCenter.Instance.EventTrigger("CreateCube", "创建了一个Cube");
    //        }
    //    }

    void CreatCube(object obj)
    {
        PoolManager.Instance.GetObj("Cube", transform);
    }

    void Print()
    {
        Debug.Log(1);
    }

    IEnumerator Test01()
    {
        yield return 0;
        Debug.Log(1);
    }
    IEnumerator Test02(string str)
    {
        yield return 0;
        Debug.Log(str);
    }
    IEnumerator Test03(string str, string str1)
    {
        yield return 0;
        Debug.Log(str + str1);
    }
}
