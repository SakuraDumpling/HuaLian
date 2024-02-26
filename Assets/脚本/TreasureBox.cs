using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    private bool canOpen;   //可以打开的状态
    private bool isOpen;    //是否打开
    private Animator anim;  //导入动画

    public GameObject coin;     //金币（暂时用金币代替，后续还需要更改）
    public float delayTime;     //延迟时间

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
        for (int i = 0; i <= 10; i++)
        {
            Instantiate(coin, transform.position, Quaternion.identity);     //生成一个金币
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
}
