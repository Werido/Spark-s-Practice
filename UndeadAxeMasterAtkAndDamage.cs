using UnityEngine;
using System.Collections;

public class UndeadAxeMasterAtkAndDamage : ATKandDamage
{

    private Transform Player;
    //public AudioClip BossAttackClip;
    void Awake()
    {
        base.Awake();
        Player = GameObject.FindGameObjectWithTag(TagMgr.Player).transform;
    }

    public void Attack1()
    {
        //AudioSource.PlayClipAtPoint(BossAttackClip, transform.position, 1f);
        if (Vector3.Distance(transform.position, Player.position) < attackDistance)
        {
            Player.GetComponent<ATKandDamage>().TakeDamage(normalAttack);
        }
    }

    public void Attack2()
    {
        //AudioSource.PlayClipAtPoint(BossAttackClip, transform.position, 1f);
        if (Vector3.Distance(transform.position, Player.position) < attackDistance)
        {
            Player.GetComponent<ATKandDamage>().TakeDamage(normalAttack);
        }
    }

    public override int ScoreAward()
    {
        return 100;
    }
}
