using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterRoom : MonoBehaviour {
    public GameObject lightOne;
    public GameObject lightTwo;
    public GameObject cameraOne;
    public GameObject cameraTwo;

    public void switchCamera()
    {
        if (cameraOne.activeSelf == true)
        {
            cameraOne.SetActive(false);
            lightOne.SetActive(false);
            lightOne.GetComponent<Light>().enabled = false;
            cameraTwo.SetActive(true);
            lightTwo.SetActive(true);
            lightTwo.GetComponent<Light>().enabled = true;

        }
        else
        {
            cameraOne.SetActive(true);
            lightOne.SetActive(true);
            lightOne.GetComponent<Light>().enabled = true;
            cameraTwo.SetActive(false);
            lightTwo.SetActive(false);
            lightTwo.GetComponent<Light>().enabled = false;

        }
    }
}
