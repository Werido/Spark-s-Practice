using UnityEngine;
using System.Collections;


public enum enemyType
{
    ARCHER,
    MASTER,
    NECRO,
    WARRIOR,
    MINION,  //召唤物
    SOULMONSET,
    SOULBOOS,
    AXEMASTER,
    NONE,
}

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public enemyType type;

    public GameObject SpawnInit()
    {
        if (type == enemyType.NONE)
            return null;
        prefab = AllCacheController.instance.popItem(type);
        //启用并生成小地图标识
        prefab.SetActive(true);
        //prefab.GetComponent<EnemyIcon>().setIconActive();
        //此处应该是取到对象池的游戏对象以后对Enemy对象进行类型赋值

        return GameObject.Instantiate(prefab, transform.position, transform.rotation) as GameObject;
        //EnemyCache xx = new EnemyCache(prefab, prefab);
        //xx.init(2, 5);
        //return GameObject.Instantiate(prefab, transform.position, transform.rotation) as GameObject;
    }

}
  