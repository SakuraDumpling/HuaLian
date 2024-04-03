using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FadeIn : MonoBehaviour
{
    public float appearTime;  //出现时间
    public UnityEngine.UI.Image img;   //图像

    public GameObject imgTransform;     //存储位置
    public float floatUnit;             //浮动单位
    public float timFloat;              //浮动时间

    // Start is called before the first frame update
    void Start()
    {
        AnimEnter.FadeIn(appearTime, img);
        MainMenuFloat.Float(floatUnit, timFloat, imgTransform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
