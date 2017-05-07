using UnityEngine;
using System.Collections;
using System;

public class EnemyCache : CacheController<GameObject, GameObject>
{
    public EnemyCache(GameObject _t, GameObject _temp) : base(_t, _temp)
    {
    }

    public override GameObject createItem(GameObject _temp)
    {
        return _temp;
    }

    public override void discardItem(GameObject _t)
    {
        GameObject.DestroyImmediate(_t);
    }

    public override void resetItem(GameObject _t)
    {
        if (_t == null)
        {
            Debug.LogError("reset Item is null");
            return;
        }
        _t.gameObject.GetComponent<ATKandDamage>().hp = 100;
        _t.gameObject.GetComponent<ATKandDamage>().HpSlider.value = 1;
        _t.gameObject.GetComponent<EnemyIcon>().setUnActive();
        _t.SetActive(false);
        //StartCoroutine(reset(_t));

    }

    //IEnumerator reset(GameObject _t)
    //{
    //    yield return new WaitForSeconds(1f);
    //    _t.SetActive(false);
    //    _t.gameObject.GetComponent<ATKandDamage>().hp = 100;
    //    _t.gameObject.GetComponent<ATKandDamage>().HpSlider.value = 1;
    //}
}
