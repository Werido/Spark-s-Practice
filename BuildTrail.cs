using UnityEngine;
using System.Collections;

public class BuildTrail : MonoBehaviour
{

    public WeaponTrail SingletTrail;
    private float t = 0.033f;
    private float tempT = 0;
    private float animationIncrement = 0.003f;

    void LateUpdate()
    {
        t = Mathf.Clamp(Time.deltaTime, 0, 0.066f);

        if (t > 0)
        {
            while (tempT<t)
            {
                tempT += animationIncrement;

                if (SingletTrail.time > 0)
                {
                    SingletTrail.Itterate(Time.time-t+tempT);
                }
                else
                {
                    SingletTrail.ClearTrail();
                }
            }

            tempT -= t;
            if (SingletTrail.time > 0)
            {
                SingletTrail.UpdateTrail(Time.time,t);
            }
        }
    }
}
