using UnityEngine;
using System.Collections;
using System;

//奖励类型枚举
public enum AwardType
{
    Blood,
    CD,
    MOVE,
}

public class PlayerAword : MonoBehaviour
{
    //奖励存在的时间
    public float ExitTime = 10;

    //奖励使用时间倒计时
    void Update()
    {
        if (ExitTime > 0)
        {
            ExitTime -= Time.deltaTime;
            if (ExitTime < 0)
            {
                setSpeedBack();
            }
        }
    }

    //获取奖励
    public void GetAward(AwardType type)
    {
        if (type == AwardType.Blood)
        {
            PlayerHeal();
        }
        else if (type == AwardType.CD)
        {
            RemoveCDtime();
        }
        else
            changeMoveSpeed();
    }

    //回复初始速度
    void setSpeedBack()
    {
        PlayerMove._instance.speed -= 1.5f;
    }

    //加速
    void changeMoveSpeed()
    {
        PlayerMove._instance.speed += 1.5f;
    }

    //加血
    void PlayerHeal()
    {
        GameObject.FindGameObjectWithTag(TagMgr.Player).GetComponent<PlayerAtkAndDamage>().getHealth();
        ExitTime = 0;
    }

    //减少CD
    void RemoveCDtime()
    {
        GameObject.FindGameObjectWithTag(TagMgr.Player).GetComponent<PlayerAtkAndDamage>().setDeltaTime();
    }
}
