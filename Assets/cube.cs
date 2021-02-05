/* 
*********************************************************************
Copyright (C) 2021 The Company Name
Author:              第五枫咏
CreateTime:          2021/1/30
********************************************************************* 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("DelayDestroy",1);
    }

    void DelayDestroy()
    {
        PoolManager.Instance.SetObj(gameObject);
    }
}
