using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randombox : MonoBehaviour
{
    //随机金币
    [SerializeField] private Transform coinParent;  //序列化一个位置用来存放金币位置
    //[SerializeField] private int positionMin, positionMax;  //随机位置的最大值和最小值
    [SerializeField] private int rotationMin, rotationMax;  //随机角度的最大值最小值
    private List<GameObject> _coinList = new List<GameObject>();//为了动画方便控制所以需要建一个宿主,因为我这里直接获取的金币预制体所以用gameobject
    private int _coinNum = 0;   //单次生成的
    public GameObject coinPrefab;     //金币

    public Transform positionMin,positionMax;     //位置信息

    private bool canOpen = true;   //可以打开的状态
    private bool isOpen;    //是否打开
    private Animator anim;  //导入动画
    public float delayTime;     //延迟时间

    void Start()
    {
        anim = GetComponent<Animator>();       //初始化动画组件
        isOpen = false;     //将刚开始的状态设置为假
        //coinPrefab = GetComponent<GameObject>();    //初始化金币
        //MakeTweens();   //飞入动画
    }

    ///
 
    public void Reward()
    {
        _coinList.Clear();  //首先清理一下这个列表保证每次调用是空值
        //Debug.Log("清理完毕");
        //GenerateCoins();    //调用生成金币的函数
    }


    void Update()
    {
        //Debug.Log("清理列表");
        Reward();
        //_coinList.Clear();  //首先清理一下这个列表保证每次调用是空值
        
        //如果获取到的按键为I
        if (Input.GetKeyDown(KeyCode.I))
        {
            //Debug.Log(canOpen);
            //宝箱处于能打开且没有打开的状态
            if (canOpen && !isOpen)
            {
                //Debug.Log(canOpen);
                anim.SetTrigger("Opening");     //播放打开动画
                AudioManager.Instance.PlaySFX("OpenBox");   //音效

                isOpen = true;      //修改为true
                Invoke("GenerateCoins", delayTime);   //延迟时间
                //GenerateCoins();
                //Debug.Log("生成金币");
            }
        }
    }

    //随机生成金币
    private void GenerateCoins()
    {
        int num = Random.Range(10, 20); //随机生成10-20个金币
        for (int i = 0; i < num; i++)
        {
            GameObject coin = Instantiate(coinPrefab, Vector2.zero, Quaternion.identity, coinParent);   //生成金币，设置初始角度为0，角度为初始角度，父物体为coinParent
            coin.transform.localPosition = new Vector2(Random.Range(positionMin.position.x, positionMax.position.y + 1),
                Random.Range(positionMin.position.x, positionMax.position.y + 1));    //设置成随机位置
            coin.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(rotationMin, rotationMax + 1)));  //生成随机角度
            _coinList.Add(coin);    //赋值到这个列表里去
            //Debug.Log("生成1次");
        }
        _coinNum = num; //计数
        //Debug.Log();
    }

    //飞入动画
    private void MakeTweens()
    {
        float delay = 0f;   //分成小类，不然容易遮盖住效果不明显
        for (int i = 0; i < _coinNum; i++)
        {
            
        }
    }
}
