using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    public float speed = 2; //相机移动速度
    public AudioClip victorClip;
    public static FollowPlayer _instance;

    void Awake()
    {
        _instance = this;
        //DontDestroyOnLoad(this);
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagMgr.Player).transform;
    }

    public void VictorSound()
    {
        AudioSource.PlayClipAtPoint(victorClip, transform.position, 100f);
    }
    void Update()
    {
        //相机跟随
        Vector3 targetPos = player.position + new Vector3(3f, 5f, -5f);
        transform.position = Vector3.Lerp(transform.position,targetPos, speed*Time.deltaTime);
        //注视主角
        Quaternion Targetrotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(
            transform.rotation, Targetrotation, speed * Time.deltaTime);

    }
}
