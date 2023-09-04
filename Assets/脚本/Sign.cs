using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;     //图像,因为后面要调用的方法用image是调用不了的，所以要用GameObject
    public Text dialogBoxText;  //文本
    public string signText;     //显示的招牌文字
    private bool isPlayerInSign;   //判断是否和玩家接触了

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //如果按下了E，并且玩家在这个范围内
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInSign)
        {
            dialogBoxText.text = signText;  //将输入的文本赋值给它
            dialogBox.SetActive(true);  //显示这个文本
        }
    }

    //标识牌触发函数
    void OnTriggerEnter2D(Collider2D orther)
    {
        //Debug.Log("进入招牌范围");
        //如果碰到的是玩家,且碰到的是胶囊体的
        if (orther.gameObject.CompareTag("Player") && 
            orther.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //Debug.Log("进入招牌范围");
            isPlayerInSign = true;  //进入范围标记为真
        }
    }

    //标识牌退出函数
    void OnTriggerExit2D(Collider2D orther)
    {
        //Debug.Log("离开招牌范围");
        if (orther.gameObject.CompareTag("Player") &&
            orther.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //Debug.Log("离开招牌范围");
            isPlayerInSign = false;  //进入范围标记为假
            dialogBox.SetActive(false);  //显示这个文本
        }
    }
}
