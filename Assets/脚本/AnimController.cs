using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimController : MonoBehaviour
{

    public float moveUnit;  //移动位置
    public float appearTime;  //出现时间
    public RectTransform rectTransform;//坐标组件
    public Image img;   //图像

    public GameObject imgTransform;     //存储位置
    public float floatUnit;             //浮动单位
    public float timFloat;              //浮动时间

    // Start is called before the first frame update
    void Start()
    {
        //animenter = new AnimEnter();    //初始化,可以运行，但是有黄色警告
        //animenter = GetComponent<AnimEnter>();      //获取脚本组件
        AnimEnter.PositionMoveX(moveUnit, rectTransform);
        AnimEnter.FadeIn(appearTime, img);

        //MainMenuFloat.Float(floatUnit, timFloat, imgTransform);     //浮动代码
    }

    // Update is called once per frame
    void Update()
    {

    }



}
