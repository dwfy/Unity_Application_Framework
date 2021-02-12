/* 
*********************************************************************
Copyright (C) 2021 The Company Name
Author:              第五枫咏
CreateTime:          2021/2/6
********************************************************************* 
*/
/// <summary>
/// 用来存储游戏中的常量，如事件名等
/// </summary>
public class GameConst
{
    #region 事件中心事件名，统一加在这个区域，如果要细分再优化

    public const string ON_LOAD_SCENE = "ON_LOAD_SCENE";        //异步加载场景事件

    #endregion

    #region 音乐音效
    //-----------------------音乐----------------------------
    public const string BGM01 = "Music/BGM/bgm01";

    //-----------------------音效----------------------------
    public const string SOUND01 = "Music/Sounds/victory";

    #endregion

}
