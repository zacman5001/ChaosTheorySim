using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createAtCurser : MonoBehaviour {

    public GameObject zone;
    public GameObject road;
    public GameObject assignLandPanel;
    public GameObject manager;
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
                GameObject justPlaced = Instantiate(placedObject, hit.point, Quaternion.identity);
                if (placedObject == zone) {
                    justPlaced.GetComponent<ActivityZone>().assignLandContent = this.assignLandPanel;
                    justPlaced.GetComponent<ActivityZone>().manager = this.manager;
                    justPlaced.GetComponent<ActivityZone>().CheckOwnership();
                }
            }
        }
    }
}
