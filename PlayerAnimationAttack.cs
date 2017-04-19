using System;
using UnityEngine;
using System.Collections;

public class PlayerAnimationAttack : MonoBehaviour
{
    private Animator animator;
    private bool isCanAttackB;
    private float cdTime = 0f;


    #region 攻击事件处理初始化
    //为攻击按钮绑定监听方法
    void Start ()
	{
	    animator = this.GetComponent<Animator>();
        //将当前脚本的点击事件处理方法放到OnClick事件触发列表中
        EventDelegate NormalAttackEvent = new EventDelegate(this, "OnNormalAttackClick");
        GameObject.Find("NormalAttack").GetComponent<UIButton>().onClick.Add(NormalAttackEvent);

        EventDelegate RangeAttackEvent = new EventDelegate(this, "OnRangeAttackClick");
        GameObject.Find("RangeAttack").GetComponent<UIButton>().onClick.Add(RangeAttackEvent);

        GameObject Redattack = GameObject.Find("RedAttack");
        EventDelegate RedAttackEvent = new EventDelegate(this, "OnRedAttackClick");
        Redattack.GetComponent<UIButton>().onClick.Add(RedAttackEvent);
        Redattack.gameObject.SetActive(false);

    }
    #endregion

    #region 角色战斗动画处理

    public void OnNormalAttackClick()
    {
        animator.speed = 1.4f;//动画加速
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA"))
        {
            animator.SetTrigger("AttackA");
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA")
    && isCanAttackB)
        {
            animator.SetTrigger("AttackB");
        }
        animator.speed = 1f;
    }

    public void OnRangeAttackClick()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackRange"))
        {
            animator.SetTrigger("AttackRange");
        }
    }

    public void OnRedAttackClick()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackGun"))
        {
            animator.SetTrigger("AttackGun");
        }
    }

    public void AttackBEvent1()
    {
        isCanAttackB = true;
    }

    public void AttackBEvent2()
    {
        isCanAttackB = false;
    }

    #endregion
}
