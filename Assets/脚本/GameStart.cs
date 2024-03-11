using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public VideoPlayer cutsceneCortroller;  //过场动画视频播放器
    public GameObject cutsceneUI;     //播放器的UI


    // Start is called before the first frame update
    void Start()
    {
        cutsceneCortroller.loopPointReached += End;     //以委托的方式，执行如果播放结束进行结束方法
        cutsceneCortroller.started += Begin;            //开始
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //播放结束
    public void End(VideoPlayer cortroller)
    {
        cutsceneUI.SetActive(false); //隐藏父物体
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   //切换下一个场景
    }

    //开始播放
    public void Begin(VideoPlayer cortroller)
    {
        cutsceneUI.SetActive(true); //显示
    }
}
