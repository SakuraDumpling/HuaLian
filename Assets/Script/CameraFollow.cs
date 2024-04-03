using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    //位置信息
    public float smoothing;     //平滑因子

    public Vector2 minPosition;  //最小的位置坐标
    public Vector2 maxPosition;  //最大的位置坐标

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //相机跟随
    void LateUpdate()
    {
        //如果玩家被干掉了，判定就会为空
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;    //声明一个3维局部变量
                //限制相机范围，有问题所以需要重新来
                /*
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
                */

                //相机移动
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);    //
            }
        }
    }

    //给其他调用的，暂时没啥用
    public void SetCamPosLink(Vector2 minPos, Vector2 maxPos) 
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }

}
