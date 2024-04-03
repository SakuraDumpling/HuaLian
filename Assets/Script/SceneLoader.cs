using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject eventObj;     //保存一起随UI生成的eventsystem
    public GameObject canvas;   
    public Animator animator;       //存储动画

    public static SceneLoader Instance;     //将此脚本设置为单例方便调用

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

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);  //将过场的这个UI画布设置为不会被销毁
        //GameObject.DontDestroyOnLoad(this.eventObj);    //将system保存
        //GameObject.DontDestroyOnLoad(this.canvas);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        StartCoroutine(LoadScene(0));
        StartCoroutine(LoadScene(1));   //切换场景，括号里的数字是set build里面的场景顺序
        */
    }

    //淡入
    IEnumerator LoadScene(int index)
    {
        animator.SetBool("FadeIn", true); 
        animator.SetBool("FadeOut", false);     //将这个设为false，防止出错

        yield return new WaitForSeconds(1); //等待一秒

        AsyncOperation async =  SceneManager.LoadSceneAsync(index);     //加载场景采用异步加载，这段时间播放渐入渐出动画
        async.completed += OnLoadedScene;       //回调
    }

    public void OnLoadedScene(AsyncOperation obj)
    {
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
    }

    //调用前面的协程
    public void FadeIn(int j)
    {
        StartCoroutine(LoadScene(j));
        //StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));    //切换场景
    }
    
    //下一关
    public void FadeNext()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //上一关
    public void FadePrevious()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex -1));
    }
}
