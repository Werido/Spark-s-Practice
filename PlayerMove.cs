using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove _instance;
    private CharacterController cc;
    public float speed = 4;
    private Animator animator;
    private Vector3 targetDir;
    public Vector3 _targetDir { get { return targetDir; } }

    #region 角色移动控制
    void Awake()
    {
        cc = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
        _instance = this;
    }

    void Update()
    {
        //获取x,y方向的偏移值
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (JoyStick.h!=0|| JoyStick.v!=0)  
        {
            h = JoyStick.h;
            v = JoyStick.v;
        }

        //改变朝向
        if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
        {
           // 改变行走状态
           animator.SetBool("Walk",true);
            //播放行走动画时才产生移动，否则移动动画和攻击动画会重合
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))
            {
                targetDir = new Vector3(h, 0, v);
                transform.LookAt(targetDir + transform.position);
                cc.SimpleMove(transform.forward * speed);
            }
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
    #endregion
}
