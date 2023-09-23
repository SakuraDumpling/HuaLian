using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseMap : MonoBehaviour
{
    public GameObject tipIcon;      //
    private bool canTalk = false;   //判断是否能可以显示
    // 墙壁的Tilemap Renderer组件
    //public TilemapRenderer wall;
    // Start is called before the first frame update
    void Start()
    {
        tipIcon.SetActive(true);   //初始设置为显示
        
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
            tipIcon.SetActive(false);    //隐藏提示框
            //wall.material.color = new Color(1, 1, 1, 0); //隐藏墙壁
        }

    }

    

    
}
