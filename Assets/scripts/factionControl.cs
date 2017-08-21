using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class factionControl : MonoBehaviour
{

    //---------
    //Dispositions
    //---------
    public float aggression;
    public float zeal;
    public float fulfillment;
    public float entertainment;
    public float luxury;

    //---------
    //Determinates
    //---------

    float appraisal;
    float dispositionInertia;
    float revoltRisk;

    //----------
    //Resources
    //----------

    //General resources
    public float coins;

    //Construction Resources
    public int logs;
    public int planks;
    public int bricks;

    //Mining Resources
    public int stone;
    public int ironOre;
    public int coal;
    public int clay;
    public int copper;
    public int tin;
    public int goldOre;
    public int steelBars;
    public int goldBars;
    public int bronzeBars;

    //Food Resources
    public int cattle;
    public int grain;
    public int flour;
    public int bread;
    public int meat;
    public int fish;

    //War resources
    public int swords;
    public int spears;
    public int bows;
    public int crossbows;
    public int muskets;
    public int cannons;

    //---------
    //Real Estate
    //---------

    public List<GameObject> tilesWithMiningRights = new List<GameObject>();
    public List<GameObject> tilesWithFarmingRights = new List<GameObject>();
    public List<GameObject> tilesWithFishingRights = new List<GameObject>();
    public List<GameObject> tilesWithHuntingRights = new List<GameObject>();
    public List<GameObject> tilesWithBuildingRights = new List<GameObject>();

    //---------
    //Evaluative Lists
    //---------

    List<GameObject> mineableTiles = new List<GameObject>();
    List<GameObject> huntableTiles = new List<GameObject>();
    List<GameObject> buildableTiles = new List<GameObject>();
    List<GameObject> fishableTiles = new List<GameObject>();
    List<GameObject> farmableTiles = new List<GameObject>();

    List<GameObject> wantToBuild = new List<GameObject>();

    //---------
    //Evaluations
    //---------



    //---------
    //Actions
    //---------





    //---------
    //Invocations
    //---------

}

