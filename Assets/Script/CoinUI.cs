using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public int startCoinQuantity;   //初始金币数量，并显示出来
    public Text coinQuantity;   //存放显示文本的变量

    public static int CurrentCoinQuantity;  //当前金币的数量

    // Start is called before the first frame update
    void Start()
    {
        CurrentCoinQuantity = startCoinQuantity;    //将初始金币数量赋给当前金币数量
    }

    // Update is called once per frame
    void Update()
    {
        coinQuantity.text = CurrentCoinQuantity.ToString();    //将数值显示出来
    }
}
