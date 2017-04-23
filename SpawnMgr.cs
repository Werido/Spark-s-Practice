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

    void Awake()
    {
        _instance = this;
    }
	void Start ()
	{
	    StartCoroutine(Spawn());
	}
	
	void Update () {
	
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

        //等待游戏结束
        while (EnemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        //FollowPlayer.instance().VictorSound();
        int temp = PlayerPrefs.GetInt("LevelPass");
        PlayerPrefs.SetInt("LevelPass",++temp);
        NextInterface.SetActive(true);
    }
}
  