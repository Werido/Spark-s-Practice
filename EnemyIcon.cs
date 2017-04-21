using UnityEngine;
using System.Collections;

public class EnemyIcon : MonoBehaviour
{
    private Transform icon;
    private Transform player;

    //根据角色类型获取对应小地图标识
	void Start () {
	    if (this.tag == TagMgr.SoulBoss)
	    {
	        icon = MiniMap._instance.GetBossIcon().transform;
	    }
	    else
	    {
	        icon = MiniMap._instance.GetMonsterIcon().transform;
	    }
	    player = GameObject.FindGameObjectWithTag(TagMgr.Player).transform;
	}
	
    //根据AI与角色的位置偏移量设置图标在小地图的坐标
	void Update ()
	{
	    Vector3 offset = transform.position - player.position;
        //三维转二维坐标，三维的z轴是二维的y轴
        icon.localPosition = new Vector3(offset.x*7,offset.z*7,0);
	}

    void OnDestroy()
    {
        if (icon != null)
        {
            Destroy(icon.gameObject);
        }
    }
}
