using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpike : MonoBehaviour
{
    public GameObject hideSpikeBox;     //地刺框
    public float time;      //地刺出现时间

    private Animator anim;      //获取动画


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    //导入
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //触发的方法,其实也可以用调用的方法
    private void OnTriggerEnter2D(Collider2D other)
    {
        //只检测和玩家的多边形碰撞体碰撞
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            //playerHealth.DamgePlayer(damge);    //调用伤害函数
            StartCoroutine(SpikeAttack());  //启动协程
        }
    }

    //协程
    IEnumerator SpikeAttack()
    {
        yield return new WaitForSeconds(time);
        anim.SetTrigger("Attack");      //播放动画
        Instantiate(hideSpikeBox, transform.position, Quaternion.identity);     //让触发框使玩家受到伤害
    }
}
