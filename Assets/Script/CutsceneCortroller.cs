using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;    //获取包含视频的包

public class CutsceneCortroller : MonoBehaviour
{
    //过场动画脚本
    public VideoPlayer cutsceneCortroller;  //过场动画视频播放器
    public GameObject cutsceneUI;     //播放器的UI
    public VideoClip[] cutsceneGroup;     //存放多个视频的剧情动画组

    // Start is called before the first frame update
    void Start()
    {
        cutsceneCortroller.loopPointReached += End;     //以委托的方式，执行如果播放结束进行结束方法
        cutsceneCortroller.started += Begin;            //开始
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //测试功能用
        if (Input.GetKeyDown(KeyCode.A))
        {
            Toggle(0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Toggle(1);
        }
        */
    }

    //暂停或播放
    public void Pause()
    {
        if (cutsceneCortroller.isPaused)
        {
            cutsceneCortroller.Play();
        }
        else 
        {
            cutsceneCortroller.Pause();
        }
    }

    //播放结束
    public void End(VideoPlayer cortroller)
    {
        cutsceneUI.SetActive(false); //隐藏父物体
    }

    //开始播放
    public void Begin(VideoPlayer cortroller)
    {
        cutsceneUI.SetActive(true); //显示
    }

    //切换动画
    public void Toggle(int number)
    {
        cutsceneCortroller.clip = cutsceneGroup[number];    //动画控制器的序号等于剧情动画组序号
        cutsceneCortroller.Play();
    }
}
