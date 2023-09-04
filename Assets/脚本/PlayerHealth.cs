using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    public int health;  //血量
    public int Blinks;  //闪烁次数
    public float time;  //闪烁时间




    private Renderer myRender;  //用来存储显示组件
    private Animator anim;  //获取角色动画
    private ScreenFlash sf;     //获取

    private PlayerController playerController;  //获得控制的脚本


    private Rigidbody2D rb2d;     //获取刚体

    // Start is called before the first frame update
    void Start()
    {
        HealthBar.HealthMax = health;   //将最大值赋值给health
        HealthBar.HealthCurrent = health;   //将当前值给health
        myRender = GetComponent<Renderer>();    //初始化一下render
        anim = GetComponent<Animator>();    //初始化动画组件
        sf = GetComponent<ScreenFlash>();   //

        rb2d = GetComponent<Rigidbody2D>();     //调用玩家刚体
        playerController = GetComponent<PlayerController>();    //初始化调用PlayerController脚本

    }

    // Update is called once per frame
    void Update()
    {

    }

    //受到伤害函数
    public void DamgePlayer(int damage)
    {
        sf.FlashScreen();   //调用闪烁函数
        health -= damage;   //血量等于原本的减去伤害
        if (health < 0) health = 0; //如果伤害溢出，让血量显示等于0
        HealthBar.HealthCurrent = health;   //血量等于当前的
        //Debug.Log("Player health: " + health);
        //如果血量为0，消除项目
        if (health <= 0)
        {
            rb2d.velocity = new Vector2(0, 0);  //速度设为0
            //rb2d.gravityScale = 0.0f;   //重力为0
            GameCortroller.isGameAlive = false; //将状态转为false
            anim.SetTrigger("Die"); //调用死亡动画
            //Destroy(gameObject, 0.8f);    //消除这个项目

            StartCoroutine(Death());  //8秒后隐藏玩家项目
        }
        BlinkPlayer(Blinks, time);  //调用闪烁
    }

    //闪烁函数，参数是次数以及时间
    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));    //启动协成
    }

    //闪烁的协程函数
    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i < numBlinks * 2; i++)
        {
            //切换
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;    //让在这个可以显示
    }

    //死亡的协程
    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.8f);   //等待时间
        gameObject.SetActive(false);
        Revive();       //复活函数

    }

    //复活函数
    public void Revive()
    {
        transform.position = PlayerController.respawnPoint;     //将位置重置
        HealthBar.HealthCurrent = HealthBar.HealthMax;
        health = HealthBar.HealthCurrent;           //重新将生命值设为最大值    
        GameCortroller.isGameAlive = true; //将状态转为true
        rb2d.velocity = new Vector2(5, 5);      //将玩家的速度恢复，反正输入的也是，就是之后如果要在unity里该就麻烦了
        gameObject.SetActive(true);     //接触玩家的隐藏
    }

        

}