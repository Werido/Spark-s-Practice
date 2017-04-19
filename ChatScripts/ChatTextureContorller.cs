using UnityEngine;
using System.Collections;

public class ChatTextureContorller : MonoBehaviour {

    public RenderTexture t;

    void OnGUI()
    {
        if (ChatTextController.isShowEnd == false)
            this.transform.gameObject.GetComponent<UITexture>().mainTexture = t;
    }
}
