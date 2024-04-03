using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class CoinItem : MonoBehaviour
{
    [SerializeField] private Transform coinParent;  //序列化一个位置用来存放金币位置
    [SerializeField] private Image coinPrefab;  //
    [SerializeField] private int positionMin, positionMax;  //随机位置的最大值和最小值
    [SerializeField] private int rotationMin, rotationMax;  //随机角度的最大值最小值
    //[SerializeField] private Text counterText;    //教程里用到的那个插件pro版里的文字
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
            AudioManager.Instance.PlaySFX("CollectCoin");   //音效
            Destroy(gameObject);    //删掉这个对象
        }
    }

}
