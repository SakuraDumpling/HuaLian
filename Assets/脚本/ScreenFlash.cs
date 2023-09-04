using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    public Image img;   //需要控制的图像
    public float time;  //闪烁时间
    public Color flashColor;    //

    private Color defaultColor;  //保存为闪烁状态

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = img.color;   //添加在unity里的图像
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //闪烁函数
    public void FlashScreen()
    {
        StartCoroutine(Flash());     //启动协程
    }

    //添加一个协成
    IEnumerator Flash()
    {
        img.color = flashColor;     //闪烁的颜色
        yield return new WaitForSeconds(time);  //不写协程名会报错
        img.color = defaultColor;   //恢复原本的颜色
    }
}
