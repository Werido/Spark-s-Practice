using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject[] LevelObjects;
    private static int levelIndex = 10;
    public static LevelSelect _instance;

    void Awake()
    {
        _instance = this;
    }

    //获取关卡信息
    public int LevelIndex
    {
        get
        {
            return levelIndex;
        }
        set
        {
            levelIndex = value;
        }
    }

    //遍历关卡通关数据,初始化UI显示
    void Start () {
        if (PlayerPrefs.HasKey("LevelPass") == false)
        {
            PlayerPrefs.SetInt("LevelPass",1);
        }
        int index = PlayerPrefs.GetInt("LevelPass") > 5 ? 5 : PlayerPrefs.GetInt("LevelPass");
        for (int i =0;i< index; i++)
        {
            if (LevelObjects[i] == null)
                return;
            LevelObjects[i].GetComponent<UISprite>().color = new Color(1, 1, 1);
            LevelObjects[i].GetComponent<BoxCollider>().enabled = true;
            LevelObjects[i].transform.parent.FindChild("Forbid").GetComponent<UISprite>().enabled = false;
        }
	}
    #region 设置选择的关卡索引
    public void ButtonLevel1()
    {
        levelIndex = 3;
    }
    public void ButtonLevel2()
    {
        levelIndex = 4;
    }
    public void ButtonLevel3()   
    {
        levelIndex = 5;
    }
    public void ButtonLevel4()
    {
        levelIndex = 6;
    }
    public void ButtonLevel5()
    {
        levelIndex = 7;
    }

    #endregion

    //返回主菜单
    public void Return()
    {
        SceneManager.LoadScene(0);
    }
    //进入异步加载界面
    public void Load()
    {
        SceneManager.LoadScene(2);
    }

}
