using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceUIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider; //定义ui里的音乐和音效的滑动条

    //静音模块
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();    //调用静音
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    //滑块调节
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
}
