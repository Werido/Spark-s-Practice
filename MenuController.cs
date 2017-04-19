using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    public static MenuController _instance;
    public Color purple;
    public SkinnedMeshRenderer HeadrRenderer;
    public Mesh[] HeadMesheArray;
    private int headMeshIndex = 0;

    public SkinnedMeshRenderer HandRenderer;
    public Mesh[] HandMesheArray;
    private int handMeshIndex = 0;


    public SkinnedMeshRenderer FootRenderer;
    public Mesh[] FootMesheArray;
    private int footMeshIndex = 0;

    public SkinnedMeshRenderer LowerBodyRenderer;
    public Mesh[] LowerBodyMesheArray;
    private int lowerBodyMeshIndex = 0;

    public SkinnedMeshRenderer UpBodyRenderer;
    public Mesh[] UpBodyMesheArray;
    private int upBodyMeshIndex = 0;

    public SkinnedMeshRenderer[] bodyArray;
    [HideInInspector] //隐藏颜色数组面板
    public Color[] colorArray;
    private int colorIndex = 0;
    #region 角色初始化相关
    //单例，方便加载游戏场景之后获取角色外观信息
    void Awake()
    {
        _instance = this;
        //PlayerPrefs.SetInt("LevelPass",)
        //if (PlayerPrefs.("LevelPass"))

    }

    
    void Start () {
	    colorArray =new Color[] { Color.blue, Color.cyan, Color.green, purple, Color.red };
        OnChangeColor(Color.blue);
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    #region 换装
    //头部换装
    public void OnHeadMeshNext()
    {
        headMeshIndex++;
        headMeshIndex %= HeadMesheArray.Length;
        HeadrRenderer.sharedMesh = HeadMesheArray[headMeshIndex];
    }

    //手部换装
    public void OnHandMeshNext()
    {
        handMeshIndex++;
        handMeshIndex %= HandMesheArray.Length;
        HandRenderer.sharedMesh = HandMesheArray[handMeshIndex];

    }

    //上身换装
    public void OnUpBodyMeshNext()
    {
        upBodyMeshIndex++;
        upBodyMeshIndex %= UpBodyMesheArray.Length;
        UpBodyRenderer.sharedMesh = UpBodyMesheArray[upBodyMeshIndex];
    }
    //下身换装
    public void OnLowerBodyMeshNext()
    {
        lowerBodyMeshIndex++;
        lowerBodyMeshIndex %= LowerBodyMesheArray.Length;
        LowerBodyRenderer.sharedMesh = LowerBodyMesheArray[lowerBodyMeshIndex];
    }
    //足部换装
    public void OnFootMeshNext()
    {
        footMeshIndex++;
        footMeshIndex %= FootMesheArray.Length;
        FootRenderer.sharedMesh = FootMesheArray[footMeshIndex];
    }
    
    //角色颜色
    public void OnChangeColorBlue()
    {
        colorIndex = 0;
        OnChangeColor(Color.blue);
        
    }
    public void OnChangeColorCyan()
    {
        colorIndex = 1;
        OnChangeColor(Color.cyan);
    }
    public void OnChangeColorGreen()
    {
        colorIndex = 2;
        OnChangeColor(Color.green);
    }
    public void OnChangeColorPurple()
    {
        colorIndex = 3;
        OnChangeColor(purple);
    }
    public void OnChangeColorRed()
    {
        colorIndex = 4;
        OnChangeColor(Color.red);
    }

    //保存角色外观信息
    private void Save()
    {
        PlayerPrefs.SetInt("HeadMeshIndex",headMeshIndex);
        PlayerPrefs.SetInt("HandMeshIndex",handMeshIndex);
        PlayerPrefs.SetInt("ColorIndex",colorIndex);
        PlayerPrefs.SetInt("upBodyMeshIndex", upBodyMeshIndex);
        PlayerPrefs.SetInt("lowerBodyMeshIndex", lowerBodyMeshIndex);
        PlayerPrefs.SetInt("footMeshIndex", footMeshIndex);
        
    }

    //改变颜色
    private void OnChangeColor(Color c)
    {
        foreach (SkinnedMeshRenderer renderer in bodyArray)
        {
            renderer.material.color = c;
        }
    }
    #endregion

    #region 保存角色信息并加载游戏场景
    public void OnPlay()
    {
        Save();

        SceneManager.LoadScene(1);
    }
    #endregion


}
