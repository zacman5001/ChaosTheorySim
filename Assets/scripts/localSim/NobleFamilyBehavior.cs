using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NobleFamilyBehavior : MonoBehaviour {

    // Name
    private string name;

    // Decision-making metrics
    private int economicSatisfaction;
    private int politicalSatisfaction;
    private int militarySatisfaction;
    private int powerRatio;

    // Resources
    private int food;
    private int wood;
    private int iron;
    private int gold;
    private int wealth;
    private int militaryPower;

    // Attributes
    private int foodEfficiency;
    private int woodEfficiency;
    private int ironEfficiency;
    private int goldEfficiency;
    private int silverEfficiency;

    // Holdings
    private int population;
    private int numHouses;

    // Arrays
    public List<GameObject> farmableTiles = new List<GameObject>();
    public List<GameObject> huntableTiles = new List<GameObject>();
    public List<GameObject> loggableTiles = new List<GameObject>();
    public List<GameObject> scavengeableTiles = new List<GameObject>();

    // TODO need to add code for AI just regularly maintaining itself (upkeep costs, etc.)

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
