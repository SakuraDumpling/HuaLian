using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimControllerY : MonoBehaviour
{
    public float moveUnit;  //移动位置
    public float appearTime;  //出现时间
    public RectTransform rectTransform;//坐标组件
    public Image img;   //图像

    // Start is called before the first frame update
    void Start()
    {
        AnimEnter.PositionMoveY(moveUnit, rectTransform);
        AnimEnter.FadeIn(appearTime, img);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
