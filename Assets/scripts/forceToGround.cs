using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceToGround : MonoBehaviour
{

    void Start()
    {
        Vector3 pos = transform.position;
        pos.y = Terrain.activeTerrain.SampleHeight(transform.position);
        transform.position = pos + new Vector3 (0,-10,0);
    }
}   