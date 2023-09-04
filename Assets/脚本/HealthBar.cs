using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthText;   //新建一个变量获得生命值
    public static int HealthCurrent;   //希望其他的类更快的访问，所以用静态
    public static int HealthMax;    //最大血量

    private Image healthBar;    //需要改变ui图像的属性，所以引入

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();  //初始化获取图像
        //HealthCurrent = HealthMax;  //因为刚开始的血量是满的
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)HealthCurrent / (float)HealthMax;    //因为是浮点型，所以需要强制转换
        healthText.text = HealthCurrent.ToString() + "/" + HealthMax.ToString();     //用文本显示出来
    }
}
