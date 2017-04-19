using UnityEngine;
using System.Collections;
using System;

public class PlayerDress : MonoBehaviour
{
    public SkinnedMeshRenderer HeadRenderer;
    public SkinnedMeshRenderer HandRenderer;
    public SkinnedMeshRenderer FootRenderer;
    public SkinnedMeshRenderer LowerBodyRenderer;
    public SkinnedMeshRenderer UpBodyRenderer;

    public SkinnedMeshRenderer[] bodyArray;

    #region 游戏加载完成后角色换装
    void Start ()
	{
	    InitDress();
	}


    //尸块换装
    //根据角色创建时保存的PlayerPrefs信息装饰角色
    void InitDress()
    {
        int headMeshIndex =  PlayerPrefs.GetInt("HeadMeshIndex");
        int handMeshIndex =  PlayerPrefs.GetInt("HandMeshIndex");
        int colorIndex =  PlayerPrefs.GetInt("ColorIndex");
        int upBodyMeshIndex =PlayerPrefs.GetInt("upBodyMeshIndex");
        int lowerBodyMeshIndex =PlayerPrefs.GetInt("lowerBodyMeshIndex");
        int footMeshIndex = PlayerPrefs.GetInt("footMeshIndex");

        HeadRenderer.sharedMesh = MenuController._instance.HeadMesheArray[headMeshIndex];
        HandRenderer.sharedMesh = MenuController._instance.HandMesheArray[handMeshIndex];
        UpBodyRenderer.sharedMesh = MenuController._instance.UpBodyMesheArray[upBodyMeshIndex];
        LowerBodyRenderer.sharedMesh = MenuController._instance.LowerBodyMesheArray[lowerBodyMeshIndex];
        FootRenderer.sharedMesh = MenuController._instance.FootMesheArray[footMeshIndex];
        foreach (SkinnedMeshRenderer renderer in bodyArray)
        {
            renderer.material.color = MenuController._instance.colorArray[colorIndex]; 
        }
    }
    #endregion
}
