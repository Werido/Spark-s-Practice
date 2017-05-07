using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class enemyItem
{
    public enemyType _type;
    public GameObject _go;
}

public class AllCacheController : MonoBehaviour {

    private Dictionary<enemyType,CacheController<GameObject,GameObject>> cacheControllerDic;
    public List<enemyItem> enemyItemList;
    public static AllCacheController instance;
    void Awake()
    {
        instance = this;
        cacheControllerDic = new Dictionary<enemyType, CacheController<GameObject, GameObject>>();
    }

    public GameObject popItem(enemyType _type)
    {
        if (cacheControllerDic.ContainsKey(_type))
            return cacheControllerDic[_type].popItem();
        else
        {
            for(int i = 0; i < enemyItemList.Count; i++)
            {
                if (enemyItemList[i]._type == _type)
                {
                    EnemyCache cache = new EnemyCache(enemyItemList[i]._go, enemyItemList[i]._go);
                    cache.init(2,10);
                    cacheControllerDic.Add(_type, cache);
                    return cache.popItem();
                }
            }
            Debug.LogError("找不到此类型的Go");
            return null;
        }
    }

    public void pushBackItem(GameObject _go)
    {
        if(_go == null)
            return;
        enemyType temp = _go.GetComponent<ATKandDamage>().type;
        if (cacheControllerDic.ContainsKey(temp))
        {
            cacheControllerDic[temp].pushBackItem(_go);
        }
        else
        {
            Debug.LogError("不存在该Go对象对象池");
        }
    }

    public void discardAll()
    {
        foreach (enemyType key in cacheControllerDic.Keys)
        {
            cacheControllerDic[key].discard();
        }
        Destroy(this);
    }
}
