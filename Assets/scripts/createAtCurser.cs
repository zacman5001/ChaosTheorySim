using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createAtCurser : MonoBehaviour {

    public GameObject zone;
    public GameObject road;
    GameObject placedObject;
    
    void Start()
    {
        placedObject = zone;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("z"))
        {
            placedObject = zone;
        }

        if (Input.GetKeyDown("r"))
        {
            placedObject = road;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 
            if (Physics.Raycast(ray, out hit, 10000) & (hit.collider.gameObject.name == "Terrain"))
                {
                    Instantiate(placedObject, hit.point, Quaternion.identity);
            }
        }
    }
}
