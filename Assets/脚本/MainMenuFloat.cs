using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFloat : MonoBehaviour
{

    //浮动
    private static Vector2 upFloat;    //上顶点
    private static Vector2 downFloat;  //下顶点
    public float floatUnit = 10f;  //浮动5个单位
    public float timFloat = 1.2f;
    public GameObject imgTransform;     //存储位置

    // Start is called before the first frame update
    void Start()
    {
        //测试用
        //Float();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Float(float floatUnit, float timFloat, GameObject imgTransform)
    {
        //初始设为            （原始的x，原始y+浮动的数值）
        upFloat = new Vector2(imgTransform.transform.localPosition.x, imgTransform.transform.localPosition.y + floatUnit);
        downFloat = new Vector2(imgTransform.transform.localPosition.x, imgTransform.transform.localPosition.y - floatUnit);

        //缓动
        DOTween.To(() => upFloat, x => imgTransform.transform.localPosition = x, downFloat, timFloat).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
