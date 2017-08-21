using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour {
    public GameObject tile;
    public int xWidth;
    public int yWidth;


	// Use this for initialization
	void Start () {
        for (int coordX = 0; coordX < xWidth - 1; coordX++) 
        {
            for (int coordZ = 0; coordZ < yWidth - 1; coordZ++)
            {
                Instantiate(tile, new Vector3(coordX, 0, coordZ), Quaternion.identity);
            }

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
