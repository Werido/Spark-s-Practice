using UnityEngine;
using System.Collections;


public class ChatCameraContorller : MonoBehaviour {

    public float playerQuatrenion;
    public Vector3 playerOffsetVector;

    public float enemyQuatrenion;
    public Vector3 enemyOffsetVector;

    void Start () {
        transform.rotation = Quaternion.Euler(0, playerQuatrenion, 0);
        transform.position = playerOffsetVector;
    }
	
	void Update () {
        if(ChatTextController.index%2 == 0)
        {
            transform.position = enemyOffsetVector;
            transform.rotation = Quaternion.Euler(0, enemyQuatrenion, 0);
        }
        else
        {
            transform.position = playerOffsetVector;
            transform.rotation = Quaternion.Euler(0, playerQuatrenion, 0);
        }
	
	}
}
