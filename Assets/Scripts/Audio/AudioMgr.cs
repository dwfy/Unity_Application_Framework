/* 
*********************************************************************
Copyright (C) 2021 The Company Name
Author:              第五枫咏
CreateTime:          2021/2/12
********************************************************************* 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 音乐音效管理器
/// </summary>
public class AudioMgr : SingleTon<AudioMgr>
{
    #region 构造函数
    private AudioMgr()
    {
        //初始化可以放在这里
        soundAudios = new List<AudioSource>();
        //绑定帧更新
        MonoManager.Instance.AddUpdateEvent(UpdateLogic);

        bgmObj = null;
        soundObj = null;
        bgmSource = null;
        //此处可以补上读取本地存储的音量大小进行初始化
        musicvolume = 1f;
        soundvolume = 1f;
    }
    #endregion

    #region 字段
    //音乐音量
    private float musicvolume;
    //音效音量
    private float soundvolume;
    //所有正在用到的音效
    private List<AudioSource> soundAudios;
    
    private GameObject bgmObj;
    private GameObject soundObj;
    private AudioSource bgmSource;
    #endregion

    #region 方法

    /// <summary>
    /// 帧更新逻辑
    /// </summary>
    private void UpdateLogic()
    {
        for (int i = 0; i < soundAudios.Count; i++)
        {
            AudioSource audio = soundAudios[i];
            if (!audio.isPlaying)
            {
                GameObject.Destroy(audio);
                soundAudios.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param path="path">资源路径</param>
    public void PlayBGM(string path)
    {
        if (bgmObj == null)
        {
            bgmObj = new GameObject("BGM");
            bgmSource = bgmObj.AddComponent<AudioSource>();
        }

        //异步加载音乐并播放
        ResLoadMgr.Instance.LoadResAsyn<AudioClip>(path, (clip) =>
        {
            bgmSource.clip = clip;
            bgmSource.loop = true;
            bgmSource.volume = musicvolume;
            bgmSource.Play();
        });
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="path"></param>
    /// <param name="isLoop"></param>
    /// <param name="cb"></param>
    public void PlaySound(string path, bool isLoop, UnityAction<AudioClip> cb = null)
    {
        if (soundObj == null)
        {
            soundObj = new GameObject("Sound");
        }

        AudioSource source = soundObj.AddComponent<AudioSource>();

        ResLoadMgr.Instance.LoadResAsyn<AudioClip>(path, (clip) =>
        {
            source.clip = clip;
            source.volume = soundvolume;
            source.loop = isLoop;
            source.Play();
            soundAudios.Add(source);
            cb?.Invoke(clip);
        });
    }

    public void ChangeBGMVolume(float volume)
    {
        musicvolume = volume;

        if (bgmSource != null)
        {
            bgmSource.volume = volume;
        }
    }

    public void ChangeSoundVolume(float volume)
    {
        soundvolume = volume;
    }

    public void PauseBGM()
    {
        bgmSource?.Pause();
    }

    public void UnPauseBGM()
    {
        bgmSource?.UnPause();
    }

    public void StopBGM()
    {
        bgmSource?.Stop();
    }

    #endregion

}
