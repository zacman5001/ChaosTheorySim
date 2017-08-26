using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioTurnOn : MonoBehaviour {

    void turnOn()
    {
        gameObject.GetComponent<Light>().color = new Color(0, 1, 0);
    }

    void turnOff()
    {
        gameObject.GetComponent<Light>().color = new Color(1, 0, 0);
    }

    void Start () {
        Invoke("turnOn", 0.85f);
	}

}
