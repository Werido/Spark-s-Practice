using UnityEngine;
using System.Collections;

public class UIAttack : MonoBehaviour
{
    public static UIAttack _instance;
    public GameObject normalAttack;
    public GameObject rangeAttack;
    public GameObject redAttack;
    PlayerAtkAndDamage playerAtk;

    private Animator animator;
    private bool isCanAttackB;
    private float cdTime = 0f;


    #region 攻击事件处理初始化
    //为攻击按钮绑定监听方法

    public void init()
    {
        playerAtk = GameObject.FindGameObjectWithTag(TagMgr.Player).GetComponent<PlayerAtkAndDamage>();
        animator = GameObject.FindGameObjectWithTag(TagMgr.Player).GetComponent<Animator>();
        //将当前脚本的点击事件处理方法放到OnClick事件触发列表中
        EventDelegate NormalAttackEvent = new EventDelegate(this, "OnNormalAttackClick");
        GameObject.Find("NormalAttack").GetComponent<UIButton>().onClick.Add(NormalAttackEvent);

        EventDelegate RangeAttackEvent = new EventDelegate(this, "OnRangeAttackClick");
        GameObject.Find("RangeAttack").GetComponent<UIButton>().onClick.Add(RangeAttackEvent);

        GameObject Redattack = GameObject.Find("RedAttack");
        EventDelegate RedAttackEvent = new EventDelegate(this, "OnRedAttackClick");
        GameObject.Find("RedAttack").GetComponent<UIButton>().onClick.Add(RedAttackEvent);
    }
    #endregion

    #region 角色战斗动画处理

    public void OnRangeAttackClick()
    {
        playerAtk.AnimationAttack(AttackType.SKILL);
    }

    public void OnNormalAttackClick()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("AttackA"))
        {
            animator.SetTrigger("Attack_1");
            playerAtk.AnimationAttack(AttackType.NORMAL);
        }else
            animator.ResetTrigger("Attack_1");
    }
     
    public void OnRedAttackClick()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("AttackB"))
        {
            animator.SetTrigger("Attack_2");
            playerAtk.AnimationAttack(AttackType.DOUBLE);
        }else
            animator.ResetTrigger("Attack_2");
    }

    #endregion

    void Awake()
    {
        _instance = this;
    }

    public void TurnToOneAttack()
    {
        normalAttack.SetActive(false);
        rangeAttack.SetActive(false);
        redAttack.SetActive(true);
    }

    public void TurnToTwoAttack()
    {
        normalAttack.SetActive(true);
        rangeAttack.SetActive(true);
        redAttack.SetActive(true);
    }
}
