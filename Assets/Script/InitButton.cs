using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InitButton : MonoBehaviour
{
    private GameObject lastSelect;  //代表按键对象

    // Start is called before the first frame update
    void Start()
    {
        lastSelect = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        //如果鼠标没有点击就用键盘操控否则用鼠标
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelect);
        }
        else 
        {
            lastSelect = EventSystem.current.currentSelectedGameObject;
        }
    }

    //图片缓动加载

}
