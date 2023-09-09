using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmartBat : Enemy
{
    public float speed; //追击速度
    public float radius;    //追击范围

    private Transform playerTransform;  //获得玩家的位置

    // Start is called before the first frame update
    void Start()
    {
        base.Start();   //调用父级函数
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //初始化玩家位置
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();  //调用父级的函数
        //如果玩家位置不为空
        if (playerTransform != null)
        {
            //用一个变量存储玩家与敌人之间的距离，sqrMagnitude是两点之间的距离
            float distance = (transform.position - playerTransform.position).sqrMagnitude;

            //如果距离小于检测半径开始追击
            if (distance < radius)
            {
                //从一个点移动到另一个点
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position,
                    speed * Time.deltaTime);   
            }
        }
    }
}
