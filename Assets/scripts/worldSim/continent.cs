using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continent : MonoBehaviour {

    public float inflation = 1;
    public float totalSilverInDenari;
    public float initialTotalSilverInDenari = 0;
    bool firstRun = true;
    void calculateInflation()
    {
        if (firstRun == true)
        {
            totalSilverInDenari = totalSilverInDenari + initialTotalSilverInDenari;
            firstRun = false;
        }
        else
        {
            inflation = totalSilverInDenari / initialTotalSilverInDenari;
        }
    }

    void Start()
    {
        InvokeRepeating("calculateInflation", 6f, 6f);
    }
}
