using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  //导入插件

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;    //将这个脚本存成静态方便调用

    public float fadeTime = 1f;     //控制渐变的时间
    public CanvasGroup canvasGroup; //导入控制不透明度的组件
    public RectTransform rectTransform;//坐标组件

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

    //渐入方法
    public void PaneIFadeIn()
    {
        canvasGroup.alpha = 0f;     //不透明度为0
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);//从下往上移动到初始位置
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);//淡化时间,1是可见
    }

    //渐出方法
    public void PameIFadeOut()
    {
        canvasGroup.alpha = 1f;     //不透明度为0
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, fadeTime);//淡化时间,0是不可见
    }
}
