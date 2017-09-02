using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioTurnOn : MonoBehaviour {

    void turnOnLight()
    {
        gameObject.GetComponent<Light>().color = new Color(0, 1, 0);
    }

    public void turnOn () {
        Invoke("turnOnLight", 0.85f);
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void turnOff()
    {
        gameObject.GetComponent<Light>().color = new Color(1, 0, 0);
        gameObject.GetComponent<AudioSource>().Stop();
    }
}
