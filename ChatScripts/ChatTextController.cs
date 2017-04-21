using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatTextController : MonoBehaviour {
    public static bool isShowEnd;
    public static int index = 0;
    public UILabel chatText;
    public GameObject enemySpawn;
    public GameObject chatenemy;
    protected string[] mData;
    public GameObject joysttick;
    public GameObject attack;

    void Start () {
        chatText.text = mData[index];
        index++;
        isShowEnd = false;
        joysttick.SetActive(false);
        attack.SetActive(false);;
    }
	
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            if (index > mData.Length-1)
            {
                isShowEnd = true;
                enemySpawn.SetActive(true);
                DestroyImmediate(chatenemy);
                DestroyImmediate(this.transform.gameObject);
                joysttick.SetActive(true);
                attack.SetActive(true);
                return;
            }
            chatText.text = mData[index];
            index++;
        }
    }
}
