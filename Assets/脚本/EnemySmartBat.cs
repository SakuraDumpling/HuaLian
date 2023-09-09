using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmartBat : Enemy
{
    public float speed; //移动速度
    public float startWaitTime; //等待时间
    private float waitTime;  //停留多久
    public Transform movePos;   //下一次要移动的坐标
    public Transform leftDownPos;   //指定的左下角坐标
    public Transform rightUpPos;    //指定的右上角坐标，给定这两个坐标就可以在以这两个坐标对称形成的那个四边形范围内巡逻

    public float chaseSpeed; //追击速度
    public float radius;    //追击范围

    private Transform playerTransform;  //获得玩家的位置

    // Start is called before the first frame update
    void Start()
    {
        base.Start();   //调用父级函数
        waitTime = startWaitTime;   //
        movePos.position = GetRandomPos();     //初始位置
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //初始化玩家位置
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();  //调用父级的函数
        File(); //调用转向函数

        //移动部分
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        //判断是否到达那个位置,这个Distance返回的是一个距离,小于一定距离就算到达
        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            //如果到达就移动到下一个随机的位置
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
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
                    chaseSpeed * Time.deltaTime);   
            }
        }
    }

    //获取随机位置
    Vector2 GetRandomPos()
    {
        //随机生成位置，参数需要给一个最小值一个最大值,用的是左下角和右上角的x做最小值，以左下角和右上角的y做最大值
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;  //返回这个位置
    }

    //自己加的转向功能
    void File()
    {
        //如果角色的x坐标小于下一次要移动的坐标
        if (transform.position.x < movePos.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);    //y轴旋转180
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

}
