using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class setPlayer : MonoBehaviour {
    public List<gostruct> gostructs;

    void Start () {
        int goindex = PlayerPrefs.GetInt("goIndex");
        int characterIndex = PlayerPrefs.GetInt("characterIndex");

        gostructs[goindex].go.SetActive(true);
        gostructs[goindex].character[characterIndex].SetActive(true);
        }
}
