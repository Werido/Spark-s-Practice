using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour
{
    public static MiniMap _instance;
    private Transform playerIcon;
    public GameObject enemyIconPrefab;

    void Awake()
    {
        _instance = this;
        playerIcon = transform.Find("PlayerIcon");
    }

    public GameObject GetBossIcon()
    {
        GameObject go = NGUITools.AddChild(this.gameObject, enemyIconPrefab);
        go.GetComponent<UISprite>().spriteName = "BossIcon";
        return go;
    }

    public GameObject GetMonsterIcon()
    {
        GameObject go = NGUITools.AddChild(this.gameObject, enemyIconPrefab);
        go.GetComponent<UISprite>().spriteName = "EnemyIcon";
        return go;
    }
    public Transform GetPlayerIcon()
    {
        return playerIcon;
    }
    
    public void removeIcon(Transform _go)
    {
        if (_go == null)
            return;
        NGUITools.Destroy(_go.gameObject);
    }
}
