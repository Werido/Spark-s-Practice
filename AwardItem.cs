using UnityEngine;
using System.Collections;
public enum AwardType
{
    Gun,
    DualSword
}
public class AwardItem : MonoBehaviour
{
    private bool startMove = false;
    private Transform Player;

    public float speed = 8;
    public AwardType type;
    public AudioClip PickUpClip;

	// Use this for initialization
   
	void Start () {
	    //if (this.tag == "ItemSword")
	    //{
	    //    this.type = AwardType.DualSword;
	    //}
	    //else
	    //{
	    //    this.type = AwardType.Gun;
	    //}
	    GetComponent<Rigidbody>().velocity = 
            new Vector3(Random.Range(-5,5),0,Random.Range(-5,5));
	}
	
	// Update is called once per frame
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
