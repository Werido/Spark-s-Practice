using UnityEngine;
using System.Collections;

public class SoulBoos : MonoBehaviour
{
    private PlayerAtkAndDamage playerAtkAndDamage;
    private static Transform Player;
    public float attackDistance = 1;  //这个是攻击距离
    //public float speed = 2;  //移动速度
    //private CharacterController cc;
    private Animator animator;
    public float attackTime = 3;   //攻击间隔时间
    private float attcktTimer = 4; //计时器
    //private bool IsCollision = false;   //检测是否被挡住；
    private NavMeshAgent agent;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag(TagMgr.Player).transform;
        playerAtkAndDamage = Player.GetComponent<PlayerAtkAndDamage>();
        //cc = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Awake()  
    {

    }
	
	// Update is called once per frame
	void Update ()
	{

        if (playerAtkAndDamage.hp <= 0)
        {
            animator.SetBool("Walk", false);
            return;
        }
    
        Vector3 targetPos = Player.position;
        //保证BOOS永远面朝主角，并且是在xy这个平面旋转，与y无关
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);

	    float distance = Vector3.Distance(targetPos, transform.position);
        if (distance <= attackDistance)//在攻击距离之内
        {  
            attcktTimer += Time.deltaTime;
            if (attcktTimer>attackTime)//达到攻击事件
            {
                int num = Random.Range(0, 2);
                if (num == 0)
                { 
                    animator.SetTrigger("Attack1");
                }
                else
                {
                    animator.SetTrigger("Attack2");
                }
                attcktTimer = 0;
            }
            else
            {
                animator.SetBool("Walk",false);
            }

        }
	    else//对目标进行跟踪
	    {
            //BOOS如果正在攻击时间，不允许移动
	        if (animator.GetCurrentAnimatorStateInfo(0).IsName("BossRun01"))
	        {
	            agent.SetDestination(Player.transform.position);
	        }
            animator.SetBool("Walk", true);
            //保证每次移动到主角身边时都会立马进行攻击
            attcktTimer = 4;
        }
	}
}
