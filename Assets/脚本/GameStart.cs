using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using NodeCanvas.Tasks.Actions;
using DG.Tweening;

public class GameStart : MonoBehaviour
{
    public VideoPlayer cutsceneCortroller;  //过场动画视频播放器
    public GameObject cutsceneUI;     //播放器的UI

    private SceneLoader sceneFader;    //引用淡入淡出的脚本
    public CanvasGroup canvasGroup; //导入控制不透明度的组件
    public float fadeTime = 1f;     //控制渐变的时间


    // Start is called before the first frame update
    void Start()
    {
        cutsceneCortroller.loopPointReached += End;     //以委托的方式，执行如果播放结束进行结束方法
        cutsceneCortroller.started += Begin;            //开始
        sceneFader = GetComponent<SceneLoader>();       //获取淡入淡出的组件
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //播放结束
    public void End(VideoPlayer cortroller)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.DOFade(0, fadeTime);
        //cutsceneUI.SetActive(false); //隐藏父物体，由于和场景渐入渐出配合有瑕疵所以更改
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   //切换下一个场景
        SceneLoader.Instance.FadeIn(1);     //转到开始界面
    }

    //开始播放
    public void Begin(VideoPlayer cortroller)
    {
        cutsceneUI.SetActive(true); //显示
    }
}
