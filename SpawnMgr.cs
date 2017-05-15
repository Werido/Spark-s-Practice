using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnMgr : MonoBehaviour
{
    public static SpawnMgr _instance;

    public Spawn[] mosterSpawnArray;
    public Spawn[] bossSpawnArray;
    public Spawn UnDeadMaster;
    public GameObject NextInterface;
    public List<GameObject> EnemyList = new List<GameObject>();
    PlayerAtkAndDamage playerAtkAndDamage;
    void Awake()
    {

        _instance = this;
    }
	void Start ()
	{
        playerAtkAndDamage = GameObject.FindGameObjectWithTag(TagMgr.Player).GetComponent<PlayerAtkAndDamage>();
        StartCoroutine(Spawn());
        StartCoroutine(checkOver());
    }

    IEnumerator checkOver()
    {
        while (playerAtkAndDamage.getScore < 300)
        {
            yield return new WaitForSeconds(0.2f);
        }

        GameObject[] enemy = GameObject.FindGameObjectsWithTag(TagMgr.SoulMonster);
        for (int i = 0; i < enemy.Length; i++)
        {
            GameObject.DestroyImmediate(enemy[i]);
        }
        GameObject.FindGameObjectsWithTag(TagMgr.SoulMonster);
        FollowPlayer._instance.VictorSound();
        AllCacheController.instance.discardAll();
        PlayerPrefs.SetInt("LevelPass", Mathf.Max(PlayerPrefs.GetInt("LevelPass"), LevelSelect._instance.LevelIndex - 1));
        NextInterface.SetActive(true);
    }

    IEnumerator Spawn()
    {

        ////第一波

        //EnemyList.Add(UnDeadMaster.SpawnInit());
        //while (EnemyList.Count > 0)
        //{
        //    yield return new WaitForSeconds(0.2f);
        //}

        //第一波
        foreach (Spawn s in mosterSpawnArray)
        {
            EnemyList.Add(s.SpawnInit());
        }
        while (EnemyList.Count>0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        //第二波
        foreach (Spawn s in mosterSpawnArray)
        {
            EnemyList.Add(s.SpawnInit());
        }

        yield return new WaitForSeconds(0.6f);
        foreach (Spawn s in mosterSpawnArray)
        {
            EnemyList.Add(s.SpawnInit());
        }

        while (EnemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        //第三波
        foreach (Spawn s in mosterSpawnArray)
        {
            EnemyList.Add(s.SpawnInit());
        }

        yield return new WaitForSeconds(0.6f);
        foreach (Spawn s in mosterSpawnArray)
        {
            EnemyList.Add(s.SpawnInit());
        }
        yield return new WaitForSeconds(0.6f);
        foreach (Spawn s in bossSpawnArray)
        {
            EnemyList.Add(s.SpawnInit());
        }
    }
}
  