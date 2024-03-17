using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuZoom : MonoBehaviour
{
    //缩放
    Vector2 minZoom;    //最小状态
    Vector2 maxZoom;    //最大状态
    float timeZoom = .35f;  //持续时间

    // Start is called before the first frame update
    void Start()
    {
        Zoom();
    }


    //缩放
    public void Zoom()
    {
        minZoom = new Vector2(.9f, .9f);
        maxZoom = new Vector2(1.1f, 1.1f);

        //调用插件进行缓动，最小值   一直变动的值赋给localScale  最大值   持续时间  缓动类型     线性    循环类型（最大值无限循环，类型是悠悠球）
        DOTween.To(() => minZoom, x => transform.localScale = x, maxZoom, timeZoom).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }


}
