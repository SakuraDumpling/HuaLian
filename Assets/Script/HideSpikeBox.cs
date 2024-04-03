using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpikeBox : MonoBehaviour
{
    public int damage;  //伤害值
    public float destroyTime;   //消失时间

    private PlayerHealth playerHealth;  //获取玩家生命

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>(); //初始化玩家生命
        Destroy(gameObject, destroyTime);   //碰撞框消失
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
            playerHealth.DamgePlayer(damage);    //调用伤害函数
        }
    }
}
