using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SceneLoader sceneFader;    //引用淡入淡出的脚本

    public void Start()
    {
        sceneFader = GetComponent<SceneLoader>();       //获取淡入淡出的组件
    }

    //开始游戏
    public void PlayGame()
    {
        SceneLoader.Instance.FadeIn(2);     //转到引导故事关卡
        //加载第一个场景,不能渐入渐出
        //SceneManager.LoadScene(2);
        //SceneManager.LoadScene("Scene1");     //这一句是固定打开第一个场景的意思
        //Debug.Log("开始游戏");

    }

    

    //退出游戏
    public void QuitGame()
    {
        //退出场景
        //Application.Quit();
        SceneLoader.Instance.FadeIn(6);     //转到结尾
    }

    //返回开始页面
    public void Begin()
    {
        SceneLoader.Instance.FadeIn(1);     //转到开始
    }
}
