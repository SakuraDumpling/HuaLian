using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //开始游戏
    public void PlayGame()
    {
        //加载第一个场景
        SceneManager.LoadScene(1);
    }

    //退出游戏
    public void QuitGame()
    {
        //退出场景
        Application.Quit();
    }
}
