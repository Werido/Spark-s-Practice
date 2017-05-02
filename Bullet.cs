using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float attack = 100;

    #region 子弹初始化相关

    //2秒后自动销毁
    void Start () {
	    Destroy(this.gameObject,2);
	}
	
    //匀速运动
	void Update () {

        transform.Translate(GameObject.FindGameObjectWithTag(TagMgr.Player).transform.forward* speed*Time.deltaTime);
        Debug.LogWarning(transform.forward == GameObject.FindGameObjectWithTag(TagMgr.Player).transform.forward);

    }
    #endregion

    #region 子弹伤害触发
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == TagMgr.SoulMonster||col.tag ==TagMgr.SoulBoss)
        {
            col.GetComponent<ATKandDamage>().TakeDamage(attack);
        }
    }
    #endregion
}
