using UnityEngine;
using System.Collections;

public class SoulMoster : MonoBehaviour
{

    private PlayerAtkAndDamage playerAtkAndDamage;
    private Transform Player;
    public float attackDistance = 1;  //这个是攻击距离
    //public float speed = 2.5f;  //移动速度
   // private CharacterController cc;
    private Animator animator;
    public float attackTime = 3;   //攻击间隔时间
    private float attcktTimer = 4; //计时器
    private NavMeshAgent agent;

    void Start()
    {
        //获取角色位置及血量信息
        Player = GameObject.FindGameObjectWithTag(TagMgr.Player).transform;
        playerAtkAndDamage = Player.GetComponent<PlayerAtkAndDamage>();

        //获取自身控制器及状态机
        //cc = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    //战斗相关
	void Update ()
	{
        //角色死亡后小怪停止运动
	    if (playerAtkAndDamage.hp <= 0)
	    {
            animator.SetBool("Walk",false);
	        return;
	    }
	    Vector3 targetPos = Player.position;
        //保证Monster永远面朝主角，并且是在xy这个平面旋转，与y无关
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);

	    float distance = Vector3.Distance(targetPos, transform.position);

        if (distance <= attackDistance)//在攻击距离之内
        {
            attcktTimer += Time.deltaTime;
            if (attcktTimer>attackTime)//达到攻击事件
            {
                animator.SetTrigger("Attack");
                attcktTimer = 0;
            }
            else
            {
                animator.SetBool("Walk",false);
            }

        }
	    else//对目标进行跟踪
	    {
            //Monster如果正在攻击时间，不允许移动  
	        if (animator.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))
	        {
                agent.SetDestination(Player.transform.position);
            }
            animator.SetBool("Walk", true);
            //保证每次移动到主角身边时都会立马进行攻击
            attcktTimer = 4;
        }
	}
}
