using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;      //导入DoTwwen插件
using System.Diagnostics;
using UnityEngine.Animations;
using UnityEngine.Diagnostics;
using UnityEngine.UI;
using System.Security.Principal;

public class TreasureBox : MonoBehaviour
{
    private bool canOpen;   //可以打开的状态
    private bool isOpen;    //是否打开
    private Animator anim;  //导入动画

    public GameObject coinPrefab;     //金币（暂时用金币代替，后续还需要更改）
    public float delayTime;     //延迟时间

    public Transform targetPosition;    //弹射的目标位置
    public float flightTime = 1.0f;     //金币飞行时间
    private Vector2 startpos;       //存储金币的初始位置
    private Vector2 centrePosition; //计算用的中心点
    private Vector2 c;  //将目标位置转换成vector2
    private float centreSpeed;      //中心点速度
    private float speed;    //弹射的速度

    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();       //初始化动画组件
        isOpen = false;     //将刚开始的状态设置为假
        
    }

    // Update is called once per frame
    void Update()
    {
        //如果获取到的按键为I
        if (Input.GetKeyDown(KeyCode.I))
        {
            //宝箱处于能打开且没有打开的状态
            if (canOpen && !isOpen)
            {
                anim.SetTrigger("Opening");     //播放打开动画
                AudioManager.Instance.PlaySFX("OpenBox");   //音效
                isOpen = true;      //修改为true
                Invoke("GenCoin", delayTime);   //延迟时间
            }
        }
    }

    //新增金币
    void GenCoin()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < 10; i++)
        {
            startpos = transform.position;      //记录金币的初始位置，写在这里的好处是，每次生成都会记录下生成的位置，让金币生成的位置随意偏移即可让金币的弹射位置偏移
            GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);     //生成一个金币,此处这么写时为了防止下面用到是无法正常调用coin
            coin.transform.SetParent(transform);    //将coin的父级位置设置为当前物体的位置

            //使用贝塞尔曲线模拟抛物线运动
            //coin.transform.DOPath(coinStartPosition, flightTime).SetEase(Ease.OutQuad);   //bing给出的还有问题不能用


            //最开始写的弹射
            //第一段位移的随机偏移
            Vector2 randomOffset = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(1.0f, 2.0f));    //随机生成一个二维向量范围在（-2.2），（1,2）之间
            Vector2 coinStartPosition = (Vector2)transform.position + randomOffset;    //现在的硬币位置等于之前的位置加上随机的位置
            coin.transform.DOMove(coinStartPosition, 0.3f).SetTarget(this);    //

            //第二段位移，飞向目的地
            coin.transform.DOMove(targetPosition.position, flightTime).SetTarget(this); 
            
        }
    }

    //触发开始
    private void OnTriggerEnter2D(Collider2D orther)
    {
        if (orther.gameObject.CompareTag("Player") && orther.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = true;     //状态改为真
        }
    }

    //退出的时候
    private void OnTriggerExit2D(Collider2D orther)
    {
        if (orther.gameObject.CompareTag("Player") && orther.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = false;     //状态改为假
        }
    }

    //贝塞尔曲线
    public static Vector2 Bezier(float t, Vector2 a, Vector2 b, Vector2 c)
    {
        var ab = Vector2.Lerp(a, b, t);
        var bc = Vector2.Lerp(b, c, t);
        return Vector2.Lerp(ab, bc, t);
    }

}
    