using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour {
    GameObject selected;
    GameObject previousSelected;
    Color oldColor;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000) & (hit.collider.gameObject.name != "Terrain"))
            {
                Debug.Log(hit.transform.gameObject.name);
                selected = (hit.transform.gameObject);
                if (previousSelected != null) {
                    previousSelected.GetComponent<MeshRenderer>().material.color = oldColor;
                }
                oldColor = selected.GetComponent<MeshRenderer>().material.color;
                selected.GetComponent<MeshRenderer>().material.color = new Color (1,1,222);
                previousSelected = selected;
            }
        }
        if (Input.GetKeyDown("delete"))
        {
            Destroy(previousSelected);
        }

    }
}
