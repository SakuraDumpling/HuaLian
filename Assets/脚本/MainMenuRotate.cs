using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRotate : MonoBehaviour
{
    Vector3 minRotate;
    Vector3 maxRotate;
    float timeRotate = 8.5f;

    // Start is called before the first frame update
    void Start()
    {
        Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate()
    {
        minRotate = new Vector3(0, 0, 0);
        maxRotate = new Vector3(0, 0, 360);

        //                                        动的是局部欧拉角                                                                        悠悠球会在结束点反方向旋转回去
        DOTween.To(() => minRotate, x => transform.localEulerAngles = x, maxRotate, timeRotate).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }
}
