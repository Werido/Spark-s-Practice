using UnityEngine;
using System.Collections;

public class PlayerAword : MonoBehaviour
{
    //奖励武器存在的时间
    public float ExitTime = 10;
    public float dualSwordTimer = 0;
    public float GunTimer = 0;
    public GameObject singleSwordGo;
    public GameObject DualSwordGo;
    public GameObject GunGo;



    void Update()
    {
        if (dualSwordTimer > 0)
        {
            dualSwordTimer -= Time.deltaTime;
            if (dualSwordTimer<0)
            {
                TurnToSingSword();
            }
        }
        if(GunTimer>0)
        {
            GunTimer -= Time.deltaTime;
            if (GunTimer < 0)
            {
                TurnToSingSword();  
            }
        }
    }
    public void GetAward(AwardType type)
    {
        if (type == AwardType.DualSword)
        {
            TurnToDualSword();
        }
        else if(type == AwardType.Gun)
        {
            TurnToGun();
        }
    }

    void TurnToDualSword()
    {
        DualSwordGo.SetActive(true);
        singleSwordGo.SetActive(false);
        GunGo.SetActive(false);
        dualSwordTimer = ExitTime;
        GunTimer = 0;
        UIAttack._instance.TurnToTwoAttack();
    }

    void TurnToGun()
    {
        GunGo.SetActive(true);
        singleSwordGo.SetActive(false);
        DualSwordGo.SetActive(false);
        GunTimer = ExitTime;
        dualSwordTimer = 0;
        UIAttack._instance.TurnToOneAttack();

    }

    void TurnToSingSword()
    {
        dualSwordTimer = 0;
        GunTimer = 0;
        singleSwordGo.SetActive(true);
        GunGo.SetActive(false);
        DualSwordGo.SetActive(false);
        UIAttack._instance.TurnToTwoAttack();
    }
}
