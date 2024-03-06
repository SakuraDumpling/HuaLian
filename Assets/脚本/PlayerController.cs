using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //加载场景

public class PlayerController : MonoBehaviour
{
    public float runSpeed;  //跑步速度
    public int jumpSpeed; //跳跃速度
    public float doulbJumpSpeed;    //二段跳速度
    public bool isGround;   //判断是地面
    public bool canDoubleJump;  //判断二段跳

    public GameObject fallDetector;     //用来检测下落
    public static Vector3 respawnPoint;       //存储重生位置

    private Rigidbody2D myRigidbody;    //声明2d刚体
    private Animator myAnim;    //声明动画组件
    private BoxCollider2D myFeet;   //获取我的脚的盒状碰撞体
    public Vector3 initialPosition;    //设置一个存放初始位置的变量

    //修复二段跳bug
    public float jumpForce;     //跳跃的力
    public int maxJumps;        //最大跳跃次数
    private int jumps;          //跳跃计数


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();  //获取一下刚体数据
        myAnim = GetComponent<Animator>();  //获取一下动画数据
        myFeet = GetComponent<BoxCollider2D>(); //获取盒状碰撞体
        initialPosition = transform.position;   //将现在的位置赋给这个变量，作为初始点
        respawnPoint = transform.position;      //初始化将出生位置赋值给它

        jumps = maxJumps;   //让计时器等于跳跃的最大次数
    }

    // Update is called once per frame
    void Update()
    {
        //创建一个新的三维坐标来表示fallDetector的位置
        fallDetector.transform.position = new Vector3(transform.position.x, fallDetector.transform.position.y);
        //状态为true的时候才能调用这些函数
        if (GameCortroller.isGameAlive)
        {
            Run();
            Filp();
            //Jump();
            Jump2();
            //Attack();
            CheckGround();
            SwitchAnimation();
        }
        //创建一个新的三维坐标来表示fallDetector的位置
        fallDetector.transform.position = new Vector3(transform.position.x, fallDetector.transform.position.y);

    }

    //检查地面
    void CheckGround() 
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
                   myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform"));    //如果碰到了这个layer的话isGround就会返回true
        //测试
        //Debug.Log(isGround);
    }

    //翻转
    void Filp()
    {
        bool PlayerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (PlayerHasXAxisSpeed)
        {
            //如过速度大于0.1的话才会翻转，大于0不翻转不大于0翻转
            if (myRigidbody.velocity.x > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (myRigidbody.velocity.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
        
    }

    //跑步函数
     public void Run()
    {
        float moveDir = Input.GetAxisRaw("Horizontal");     //检测运动方向，因为是水平方向所以用的是Horizontal
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);    //设定一个速度，x=方向*速度，y保持不变
        myRigidbody.velocity = playerVel;   //把速度赋值给刚体的位置

        bool PlayerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;   //一个布尔类型的变量，代表玩家的x轴速度大于一个很小很小的值（不是0）
        myAnim.SetBool("Walk", PlayerHasXAxisSpeed);    //结合上一句的意思是如果满足x轴速度大于一个很小数，这个变量就是true
        
    }


    //跳跃函数
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))    //这里的jump指的是unity接受按键的部分，一般是接受到空格键识别为jump。在编辑—>program settings->输入管理器->跳跃
        {
            //判断如果在地面上才可以跳跃
            if (isGround)
            {
                myAnim.SetBool("Jump", true);   //跳跃时布尔值jump是true，方便动画切换
                Vector2 jumpVe1 = new Vector2(0.0f, jumpSpeed); //只需要y=0即可
                myRigidbody.velocity = Vector2.up * jumpVe1;    //给一个方向
                canDoubleJump = true;   //跳起后可以二段跳
                AudioManager.Instance.PlaySFX("Jump");     //音效
            }
            else
            {
                //先判断是否能二段跳
                if (canDoubleJump)
                {
                    myAnim.SetBool("Doublejump", true);   //跳跃时布尔值jump是true，方便动画切换
                    Vector2 doubleJumpVel = new Vector2(0.0f, doulbJumpSpeed);  //给二维向量类型的变量赋值，x是0，y是二段跳的速度
                    myRigidbody.velocity = Vector2.up * doulbJumpSpeed; //给刚体的速度属性赋值，Vector2.up意思是朝向上的单位向量*速度
                    canDoubleJump = false;  //此处是跳过了，所以是false
                }
            }
        }
    }

    //修复二段跳无限跳跃的bug
    public void Jump2()
    {
        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log(jumps);
            if (jumps > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumps--;
                myAnim.SetBool("Jump", true);
                AudioManager.Instance.PlaySFX("Jump");     //音效
                Debug.Log(jumps);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumps = maxJumps;
    }




    ////攻击函数
    //void Attack()
    //{
    //    //如果按下了攻击键，此处已经在设置中定义过攻击为j
    //    if (Input.GetButtonDown("Attack"))
    //    {
    //        //检测触发器trigger后切换动画
    //        myAnim.SetTrigger("Attack");
    //    }
    //}

    //动画切换
    void SwitchAnimation()
    {
        myAnim.SetBool("Idle", false);  //初始idle是false，这句的意思其实是只有在非待机状态下才需要动画切换
        if (myAnim.GetBool("Jump"))
        {
            //判断角色是否跳跃到了最高点
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("Fall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("Fall", false);
            myAnim.SetBool("Idle", true);
        }

        /*二段跳*/
        if (myAnim.GetBool("DoubleJump"))
        {
            //判断角色是否跳跃到了最高点
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("DoubleJump", false);
                myAnim.SetBool("DoubleFall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("DoubleFall", false);
            myAnim.SetBool("Idle", true);
        }
    }

    //触发函数
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果碰到的是地图下方的碰撞体返回出生点
        if (collision.gameObject.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if(collision.gameObject.tag == "Checkpoints")
        {
            //如果碰到存档点，这个位置记录存档点的位置
            respawnPoint = transform.position;
        }
    }


}
    

