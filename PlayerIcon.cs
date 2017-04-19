using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerIcon : MonoBehaviour
{

    private Transform playerIcon;
	// Use this for initialization
	void Start ()
	{
	    playerIcon = MiniMap._instance.GetPlayerIcon();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float y = transform.localEulerAngles.y;
        playerIcon.localEulerAngles = new Vector3(0,0,-y);
	}
}
