using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class setPlayer : MonoBehaviour {
    public List<gostruct> gostructs;

    void Start () {
        if (GameObject.FindWithTag("MainCamera").GetComponent<FollowPlayer>() == null)
            GameObject.FindWithTag("MainCamera").AddComponent<FollowPlayer>();
        int goindex = PlayerPrefs.GetInt("goIndex");
        int characterIndex = PlayerPrefs.GetInt("characterIndex");
        
        gostructs[goindex].go.SetActive(true);
        gostructs[goindex].character[characterIndex].SetActive(true);
        gostructs[goindex].character[characterIndex].transform.parent = null;
        gostructs[goindex].character[characterIndex].GetComponent<PlayerAtkAndDamage>().getScore = 0;
        //初始化UIAttack
        UIAttack._instance.init();
        //开始相机追随
        FollowPlayer._instance.setTarPlayer();
        DestroyObject(this.transform.gameObject);
        }
}
