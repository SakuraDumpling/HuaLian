using DG.Tweening;
using ParadoxNotion;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class AnimEnter : MonoBehaviour
{
    public Image img;   //图像
    //public RectTransform rectTransform;//坐标组件
    public float appearTime;  //出现时间
    private static Vector2 target;     //目标位置,由于需要静态引用所以需要加上static
    //public float moveUnit;  //移动位置


    // Start is called before the first frame update
    void Start()
    {
        AnimEnter.FadeIn(appearTime, img);
    }

    

    //渐入
    public static void FadeIn(float appearTime ,Image img)
    {
        Color color = img.color;
        color.a = 0f;
        img.color = color;      //改变不透明度
        img.DOFade(1, appearTime);
    }

    //移动
    //x轴
    public  static void PositionMoveX(float moveUnit , RectTransform rectTransform)
    {
        target = rectTransform.position;   //获取当前物体的位置
        //Debug.Log(rectTransform.position);
        //Debug.Log(target);  //测试
        rectTransform.position = new Vector2(moveUnit, rectTransform.position.y);    //将物体移动到看不见的位置
        //Debug.Log(rectTransform.position);
        rectTransform.DOMove(target, 2);
        //Debug.Log(target);
    }
    //y轴
    public static void PositionMoveY(float moveUnit, RectTransform rectTransform)
    {
        target = rectTransform.position;   //获取当前物体的位置
        rectTransform.position = new Vector2(rectTransform.position.x, moveUnit);    //将物体移动到看不见的位置
        rectTransform.DOMove(target, 2);
    }

}
