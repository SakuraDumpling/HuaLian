using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFloat : MonoBehaviour
{
    //浮动
    Vector2 upFloat;    //上顶点
    Vector2 downFloat;  //下顶点
    [SerializeField]
    float duration = 10f;  //浮动5个单位
    [SerializeField]
    float timFloat = 1.2f;  

    // Start is called before the first frame update
    void Start()
    {
        //测试用
        Float();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Float()
    {
        //初始设为            （原始的x，原始y+浮动的数值）
        upFloat = new Vector2(transform.localPosition.x, transform.localPosition.y + duration);
        downFloat = new Vector2(transform.localPosition.x, transform.localPosition.y - duration);

        //缓动
        DOTween.To(() => upFloat, x => transform.localPosition = x, downFloat, timFloat).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
