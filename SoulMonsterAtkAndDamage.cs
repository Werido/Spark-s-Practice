using UnityEngine;
using System.Collections;

public class SoulMonsterAtkAndDamage : ATKandDamage
{
    private Transform Player;
    public AudioClip MonsterAttackClip;

    void Awake()
    {
        //获取自身状态机及角色位置信息
        base.Awake();
        Player = GameObject.FindGameObjectWithTag(TagMgr.Player).transform;
    }


    //状态机中添加的Event事件实现方法
    public void MonAttack()
    {
        AudioSource.PlayClipAtPoint(MonsterAttackClip, transform.position, 10f);
        if (Vector3.Distance(transform.position,Player.position)<attackDistance)
        {
            Player.GetComponent<ATKandDamage>().TakeDamage(normalAttack);
        }
    }


    public override int ScoreAward()
    {
        return 50;
    }
}
