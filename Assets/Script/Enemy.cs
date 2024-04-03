using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;//自身血量
    public int damage;//对玩家的伤害

    public float flashTime; //闪烁时间

    public GameObject dropCoin;     //掉落金币

    private SpriteRenderer sr;  //渲染精灵比如颜色、翻转、材质、遮罩等
    private Color originalColor;    //记录原始颜色

    private PlayerHealth playerHealth;  //访问玩家血量


    // Start is called before the first frame update
    public void Start()
    {
        //获取玩家的生命值组件，但直接报错，所以用的bing提供的版本
        /*
        playerHealth = GameObject.FindGameObjectsWithTag("Player").GetComponent<PlayerHealth>();
        */
        //获取生命值
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();


        sr = GetComponent<SpriteRenderer>();   //获取到控制颜色等等的组件
        originalColor = sr.color;   //将初始的颜色复制给这个变量
    }

    // Update is called once per frame
    public void Update()
    {
        //如果血量为零就消除
        if (health <= 0)
        {
            Instantiate(dropCoin, transform.position, Quaternion.identity); //掉落金币
            Destroy(gameObject);
        }
    }

    //写一个伤害玩家的方法，因为要给玩家调用所以是公开的
    public void TakeDamage(int damage)
    {
        health -= damage;
        FlashColor(flashTime); //调用闪烁函数
    }

    //定义一个方法控制闪烁颜色,传一个参数进去控制闪烁时间
     void FlashColor(float time)
    {
        sr.color = Color.red;   //颜色是红的
        Invoke("ResetColor", time);//延迟一点时间调用
    }

    //再定义一个方法
    void ResetColor()
    {
        sr.color = originalColor;   //正常状态下的颜色
    }

    //触发函数，敌人碰到玩家伤害玩家
    void OnTriggerEnter2D(Collider2D orther)
    {
        
        //如果碰到的是玩家,且碰到的是胶囊体的
        if (orther.gameObject.CompareTag("Player") && orther.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //血量不为空的条件下
            if (playerHealth != null) 
            {
                playerHealth.DamgePlayer(damage);   //受到伤害值等量的伤害
            }
        }
    }



}
