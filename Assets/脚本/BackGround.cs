using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制背景滚动
public class BackGround : MonoBehaviour
{
    [SerializeField] private Vector2 movingSpeed;   //移动速度

    private Vector2 offset;     //中转

    private Material mat;   //获取这个材质

    private void Awake()
    {
        mat = GetComponent<SpriteRenderer>().material;      //初始化

    }

    private void Update()
    {
        offset = movingSpeed * Time.deltaTime;
        mat.mainTextureOffset += offset;        //=new Vector2(offset,0)
    }
}
