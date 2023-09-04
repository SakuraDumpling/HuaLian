using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //触发函数
    void OnTriggerEnter2D(Collider2D orther)
    {
        
        //如果是玩家且碰撞到的是胶囊碰撞体
        if (orther.gameObject.CompareTag("Player") && 
            orther.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            CoinUI.CurrentCoinQuantity += 1;    //数值+1，这里估计之后得重新设置一下，得往大的设计，才能存更多去买灯
            Destroy(gameObject);    //删掉这个对象
        }
    }

}
