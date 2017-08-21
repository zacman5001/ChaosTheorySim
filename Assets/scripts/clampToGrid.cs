using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clampToGrid : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
    }

}
