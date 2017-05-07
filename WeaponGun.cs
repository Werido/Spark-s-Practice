using UnityEngine;
using System.Collections;

public class WeaponGun : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject BulletPrefab;
    //子弹伤害值
    public float attack = 100;

    //实例化子弹
    public void Shot()
    {
        StartCoroutine(Spawn());
    }





    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1f);
        if (BulletPrefab != null)
        {
            GameObject go = GameObject.Instantiate(BulletPrefab, bulletPos.position, transform.root.rotation) as GameObject;
            //go.GetComponent<Bullet>().attack = attack;
        }
    }
}
