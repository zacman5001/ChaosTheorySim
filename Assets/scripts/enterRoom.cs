using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterRoom : MonoBehaviour {
    public GameObject lightOne;
    public GameObject lightTwo;
    public GameObject cameraOne;
    public GameObject cameraTwo;

    void switchCamera()
    {
        if (cameraOne.active == true)
        {
            cameraOne.SetActive(false);
            lightOne.SetActive(false);
            cameraTwo.SetActive(true);
            lightTwo.SetActive(true);
        }
        else
        {
            cameraOne.SetActive(true);
            lightOne.SetActive(true);
            cameraTwo.SetActive(false);
            lightTwo.SetActive(false);
        }
    }
}
