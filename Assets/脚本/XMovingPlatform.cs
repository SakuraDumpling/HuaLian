using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMovingPlatform : MonoBehaviour
{
    public float speed;     //移动速度
    public float waitTime;      //移动时间
    public Transform[] movePos;     //位置信息

    private int i;  //用来定位和位置之间的
    private Transform playerDeftransform;   //一个默认的关系

    // Start is called before the first frame update
    void Start()
    {
        i = 1;
        //初始化
        playerDeftransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        //从现在的位置以一定速度移动到我想要的位置
        transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);
        //判断当前位置是目标位置是否小于一个很小的值
        if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
        {
            //判断如果等待时间小于0时，再判断一下位置是0号位置还是1号位置
            if (waitTime < 0.0f)
            {
                if (i == 0) 
                { 
                    i = 1; 
                }
                else 
                { 
                    i = 0; 
                }

                waitTime = 0.5f;    //重置等待时间
            }
            else
            {
                waitTime -= Time.deltaTime;  //否则让它慢慢减小
            }
        }
    }

    //触发
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = playerDeftransform;
        }
    }
}
