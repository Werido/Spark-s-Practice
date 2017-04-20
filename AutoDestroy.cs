using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
	void Start () {
	    Destroy(this.gameObject,1);
	}
}
