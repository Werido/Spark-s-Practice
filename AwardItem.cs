using UnityEngine;
using System.Collections;
using System;
//奖励类型枚举
public enum AwardType
{
    Gun,
    DualSword
}
public class AwardItem : MonoBehaviour
{
    private static AwardItem _instance;
    public static AwardItem instance()
    {
        if (_instance == null)
        {
            _instance = new AwardItem();
        }
        return _instance;
    }
    //开始移动的信号值
    private bool startMove = false;
    private Transform Player;
    //奖励移动速度
    public float speed = 8;
    public AwardType type;
    public AudioClip PickUpClip;

    void Start () {
        //随机在某个方向以某个速度移动
	    GetComponent<Rigidbody>().velocity = 
            new Vector3(UnityEngine.Random.Range(-5,5),0, UnityEngine.Random.Range(-5,5));
	}

    //玩家从奖励物品附近经过，向玩家方向移动
	void Update () {
	    if (startMove)
	    {
	        transform.position = Vector3.Lerp(
                transform.position,Player.position+Vector3.up,speed*Time.deltaTime);

            if (Vector3.Distance(transform.position, Player.position + Vector3.up) <0.4f)
            {
                Player.GetComponent<PlayerAword>().GetAward(type);
                Destroy(this.gameObject);
                AudioSource.PlayClipAtPoint(PickUpClip,transform.position,1f);
            }
        }
	}

    //落地后不再有重力学效应
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == TagMgr.Ground)
        {
            //取消重力,保持动力学
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            SphereCollider col = this.GetComponent<SphereCollider>();
            //设置为触发器，调大碰撞半径
            col.isTrigger = true;
            col.radius = 3f;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == TagMgr.Player)
        {
            startMove = true;
            Player = collider.transform;
        }
    }
}
