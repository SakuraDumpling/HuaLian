using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimControllerX : MonoBehaviour
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
        AnimEnter.PositionMoveX(moveUnit, rectTransform);
        AnimEnter.FadeIn(appearTime, img);
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(imgTransform.transform.localPosition);
    }

    IEnumerator  Wait()
    {
        yield return new WaitForSeconds(1.4f);  //暂停1.4秒

        Vector2 startTransform = new Vector2(imgTransform.transform.localPosition.x, imgTransform.transform.localPosition.y);   //存储最开始的位置
        Vector2 upFloat =  new Vector2(imgTransform.transform.localPosition.x, imgTransform.transform.localPosition.y + floatUnit);
        DOTween.To(() => startTransform, x => imgTransform.transform.localPosition = x, upFloat, timFloat)
            .SetEase(Ease.Linear).SetLoops(1, LoopType.Yoyo)
            .OnComplete(() => { MainMenuFloat.Float(floatUnit, timFloat, imgTransform); });
    }

}
