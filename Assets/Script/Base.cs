using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]      //创建一个碰撞体

public class Base : MonoBehaviour
{
    public GameObject tipIcon;      //
    private bool canTalk = false;   //判断是否能可以显示

    // Start is called before the first frame update
    void Start()
    {
        tipIcon.SetActive(false);   //初始设置为不显示
    }

    // Update is called once per frame
    void Update()
    {

    }

    //触发函数
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canTalk = true;             //设置可以对话
            tipIcon.SetActive(true);    //显示提示框
        }

    }

    //退出函数
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            tipIcon.SetActive(false);   //
            canTalk = false;            //
        }
    }
}
