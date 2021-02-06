/* 
*********************************************************************
Copyright (C) 2021 The Company Name
Author:              第五枫咏
CreateTime:          2021/2/6
********************************************************************* 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
/// <summary>
/// 场景转换模块管理器，这里开始用到之前写的模块
/// </summary>
public class SceneMgr : SingleTon<SceneMgr>
{
    private SceneMgr() { }

    /// <summary>
    /// 同步加载场景
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void LoadScene(string name, UnityAction action)
    {
        SceneManager.LoadScene(name);
        //回调
        action();
    }

    /// <summary>
    /// 外部调用的异步加载场景方法
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void LoadSceneAsyn(string name, UnityAction action)
    {
        MonoManager.Instance.StartCoroutine(LoadSceneAsynCor(name, action));
    }

    /// <summary>
    /// 协程方法,异步加载场景
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    IEnumerator LoadSceneAsynCor(string name, UnityAction action)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        while (!operation.isDone)
        {
            //给事件中心发消息同步加载进度
            EventsCenter.Instance.EventTrigger(GameConst.ON_LOAD_SCENE, operation.progress);
            yield return 0;
        }
        action();
    }

}
