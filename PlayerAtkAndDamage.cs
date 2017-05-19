using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum AttackType
{
    NORMAL,
    DOUBLE,
    SKILL,
}
public class PlayerAtkAndDamage : ATKandDamage
{
    public float attackB = 80;
    public float skillDamage = 100;
    public float attackgun = 100;
    public float delatResponTime = 2f;
   

    public WeaponGun gun;
    public AudioClip ShotClip;
    public AudioClip SwardClip;
    private float skillCDTime = 15f;
    private float deltaTime = 0f;

    #region 战斗相关
    void Update()
    {
        if (deltaTime > 0)
            deltaTime -= Time.deltaTime;

        if (deltaTime < 0)
            deltaTime = 0;
    }

    public void setDeltaTime()
    {
        deltaTime -= 2f;
        if (deltaTime < 0)
            deltaTime = 0;
    }

    public float getCdDelateTime()
    {
        return deltaTime / skillCDTime;
    }
    //TODO 清除攻击缓存
    public void ResetTrigger()
    {
        _animator.ResetTrigger("Use_3");
    }

    public void getHealth()
    {
        hp += 100;
        PlayerHpSlider.value = hp / hptotal;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Use_3"))
            _animator.SetTrigger("Use_3");
        else
            _animator.ResetTrigger("Use_3");
    }
    //判定最近的敌人
    GameObject RecentEnemy(float Distance)
    {
        float distance = Distance;
        float temp;
        GameObject[] enemy = GameObject.FindGameObjectsWithTag(TagMgr.SoulMonster);
        GameObject targetEnemy = null;
        for (int i = 0; i < enemy.Length; i++)
        {
            //GameObject.DestroyImmediate(enemy[i]);
            temp = Vector3.Distance(transform.position, enemy[i].transform.position);
            if (temp < distance)
            {
                targetEnemy = enemy[i];
                distance = temp;
            }
        }

        return targetEnemy;
        //GameObject enemy = null;
        //float distance = Distance;
        //foreach (GameObject go in SpawnMgr._instance.EnemyList)
        //{
        //    float temp = Vector3.Distance(transform.position, go.transform.position);
        //    if (temp < distance)
        //    {
        //        enemy = go;
        //        distance = temp;
        //    }
        //}
        //return enemy;
    }

    //角色朝向调整

    //近战
    public void Changedirection(GameObject enemy,float attack)
    {
        if (enemy != null)
        {
            //Debug.LogWarning(enemy.name);
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            enemy.GetComponent<ATKandDamage>().TakeDamage(attack);
        }
    }

    //远程
    public void Changedirection(GameObject enemy)
    {
        if (enemy != null)
        {
            Debug.LogWarning(enemy.name);
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
        }
    }

    #endregion

    #region 为动画机中添加的Event事件添加处理方法，即攻击处理

    public void AttackA()
    {
        //根据是否有远程武器进行不同判定
        if (gun != null)
        {
            gun.attack = attackgun;
            gun.Shot();
            GameObject enemy = RecentEnemy(attackDistance);
            Changedirection(enemy, normalAttack);
        }
        else
        {
            GameObject enemy = RecentEnemy(attackDistance);
            Changedirection(enemy, normalAttack);
        }


        if (SwardClip!=null)
            AudioSource.PlayClipAtPoint(SwardClip,transform.position,1f);

    }

    public void AttackB()
    {
        if(SwardClip!=null)
            AudioSource.PlayClipAtPoint(SwardClip, transform.position, 1f);
        GameObject enemy = RecentEnemy(attackDistance);
        Changedirection(enemy,attackB);
    }

    //近身范围技
    public void AttackRange()
    {

        GameObject[] enemy = GameObject.FindGameObjectsWithTag(TagMgr.SoulMonster);
        for (int i = 0; i < enemy.Length; i++)
        {
            //GameObject.DestroyImmediate(enemy[i]);
            float temp = Vector3.Distance(transform.position, enemy[i].transform.position);
            if (temp < attackDistance)
            {
                //将符合情况的敌人放进新列表而不是直接处理，否则遍历的数组就发生了变化
                //enemyList.Add(go);
                enemy[i].GetComponent<ATKandDamage>().TakeDamage(skillDamage);
            }
        }
        //AudioSource.PlayClipAtPoint(SwardClip, transform.position, 1f);
        //遍历攻击范围内的敌人并造成伤害
        //foreach (GameObject go in SpawnMgr._instance.EnemyList)
        //{
        //    float temp = Vector3.Distance(transform.position, go.transform.position);
        //    if (temp < attackDistance)
        //    {
        //        //将符合情况的敌人放进新列表而不是直接处理，否则遍历的数组就发生了变化
        //        enemyList.Add(go);
        //    }
        //}
        ////不能遍历中修改或移除数据
        //foreach (GameObject go in enemyList)
        //{
        //    go.GetComponent<ATKandDamage>().TakeDamage(skillDamage);
        //}
    }


    public void AnimationAttack(AttackType _AttackType)
    {
        StartCoroutine(attackResponse(_AttackType,delatResponTime));
    }
    IEnumerator attackResponse(AttackType _AttackType,float _responseTime)
    {
        _responseTime -= Time.unscaledDeltaTime;

        if (_responseTime > 0)
            yield return 0;
        if (_AttackType == AttackType.NORMAL)
            AttackA();
        else if (_AttackType == AttackType.DOUBLE)
            AttackB();
        else
            Skill();
    }

    private void Skill()
    {
        //技能CD没完成则不响应
        if (deltaTime != 0)
            return;
        //setDeltaTime();
        //GameObject skill = GameObject.Instantiate(Resources.Load("SkillEffect"), transform.position + Vector3.up, transform.rotation) as GameObject;
        Destroy(GameObject.Instantiate(Resources.Load("SkillEffect"), transform.position + Vector3.up, transform.rotation) as GameObject,1f);
        AttackRange();
        deltaTime = skillCDTime;

    }

    public void AttackGun()
    {
        GameObject enemy = RecentEnemy(3f);
        Changedirection(enemy);

        //子弹的设计方法
        gun.attack = attackgun;
        gun.Shot();
        AudioSource.PlayClipAtPoint(ShotClip,transform.position,0.4f);
    }

#endregion
}
