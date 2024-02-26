using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;    //方便调用

    public Sound[] musicSounds, sfxSounds;  //声音类名称：音乐以及效果音效
    public AudioSource musicSource, sfxSource;

    //方便调用
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Start"); //  开始播放音乐
    }

    //播放声音的方法
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name); //播放的音乐在音乐的组内，按需要的名字播放

        //如果没有找到
        if (s == null)
        {
            Debug.Log("没有找到这个音乐");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    //调用音效的方法
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name); //播放的音乐在音效的组内，按需要的名字播放

        //如果没有找到
        if (s == null)
        {
            Debug.Log("没有找到这个音效");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    /*ui控制功能*/
    //静音按钮
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    //音量控制
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
