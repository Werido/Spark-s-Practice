using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    public static MenuController _instance;

    private int goIndex = 0;
    private int characterIndex = 0;
    public int goindex { set { goIndex = value; } }
    public int characterindex { set { characterIndex = value; } }
    #region 角色初始化相关
    //单例，方便加载游戏场景之后获取角色外观信息
    void Awake()
    {
        _instance = this;
    }

    
    void Start () {
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion


    //保存角色外观信息
    private void Save()
    {
        PlayerPrefs.SetInt("goIndex", goIndex);
        PlayerPrefs.SetInt("characterIndex", characterIndex);       
    }

    #region 保存角色信息并跳转到关卡选择场景
    public void OnPlay()
    {
        Save();

        SceneManager.LoadScene(1);
    }
    #endregion
}
