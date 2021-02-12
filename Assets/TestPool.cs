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
        //EventsCenter.Instance.AddListener(GameConst.ON_LOAD_SCENE, Print);
        //SceneMgr.Instance.LoadSceneAsyn("Test", Print1);
//        MonoManager.Instance.AddUpdateEvent(Print);
//        MonoManager.Instance.AddUpdateEvent(Print1);
//        StartCoroutine("Test01");
//        StartCoroutine(Test03("1","2"));
//        ResLoadMgr.Instance.LoadRes<GameObject>("Sphere");
//        ResLoadMgr.Instance.LoadResAsyn<GameObject>("Cube", (obj) => { Debug.Log(obj.name); });
//        EventsCenter.Instance.AddListener("CreateCube", CreatCube);
        AudioMgr.Instance.PlayBGM(GameConst.BGM01);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //            EventsCenter.Instance.EventTrigger("CreateCube", "创建了一个Cube");
            AudioMgr.Instance.PlaySound(GameConst.SOUND01, false, (clip) =>
            {
                Debug.Log(clip.name);
            });
        }
    }

    void CreatCube()
    {
        PoolManager.Instance.GetObj("Cube", (go) => { Debug.Log(go.name); });
    }

    void Print(object obj)
    {
        Debug.Log("加载进度: " + obj.ToString());
    }
    void Print1()
    {
        Debug.Log(2);
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
