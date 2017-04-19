using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject[] LevelObjects;
    private static int levelIndex = 10;
    //public static int LevelPass = 1;
    

    public static int LevelIndex
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

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("LevelPass") == false)
        {
            PlayerPrefs.SetInt("LevelPass",1);
        }
        for (int i =0;i<PlayerPrefs.GetInt("LevelPass");i++)
        {
            //E1C896FF
            LevelObjects[i].GetComponent<UISprite>().color = new Color(1, 1, 1); ;
            LevelObjects[i].GetComponent<BoxCollider>().enabled = true;
            LevelObjects[i].transform.parent.FindChild("Forbid").GetComponent<UISprite>().enabled = false;
        }
	}
	
	// Update is called once per frame  
	void Update () {
	
	}

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
    public void ButtonLevel6()
    {
        levelIndex = 8;
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
    public void Load()
    {
        SceneManager.LoadScene(2);
    }

}
