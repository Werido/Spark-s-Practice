using UnityEngine;
using System.Collections;

public class EnemyIcon : MonoBehaviour
{
    private Transform icon = null;
    private Transform player;
    public Transform _icon { get { return icon; } }
    //根据角色类型获取对应小地图标识
	void Start () {
        icon = transetIcon();
        player = GameObject.FindGameObjectWithTag(TagMgr.Player).transform;
	}
	
    //根据AI与角色的位置偏移量设置图标在小地图的坐标
	void Update ()
	{
        if (icon == null)
            return;
        Vector3 offset = transform.position - player.position;
        //三维转二维坐标，三维的z轴是二维的y轴
        icon.localPosition = new Vector3(offset.x*7,offset.z*7,0);
	}

    //销毁Enemy对应小地图标识
    public void setUnActive()
    {
        MiniMap._instance.removeIcon(icon);
    }

    //设置小地图图标
    public void setIconActive()
    {
        if(icon == null)
            transetIcon();
    }

    //获取图标
    public Transform transetIcon()
    {
        if (this.tag == TagMgr.SoulBoss)
        {
            return MiniMap._instance.GetBossIcon().transform;
        }
        else
        {
            return MiniMap._instance.GetMonsterIcon().transform;
        }
    }
    void OnDestroy()
    {
        if (icon != null)
        {
            Destroy(icon.gameObject);
        }
    }
}
