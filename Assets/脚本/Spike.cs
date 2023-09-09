using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damge;      //伤害值
    private PlayerHealth playerHealth;      //导入玩家的脚本获取生命值

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>(); //初始化玩家生命脚本
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //触发的方法
    private void OnTriggerEnter2D(Collider2D other)
    {
        //只检测和玩家的多边形碰撞体碰撞
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            playerHealth.DamgePlayer(damge);    //调用伤害函数
        }
    }
}
