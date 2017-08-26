using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estate : MonoBehaviour {

    //--------------------
    //Variables and lists
    //--------------------

    //Hardcoded cost variables
    int mineCost = 20000;
    int lumberMillCost = 10000;
    int farmCost = 12000;
    int workshopCost = 12000;
    int dockCost = 20000;
    int churchCost = 5000;
    int cathedralCost = 500000;
    int silverMod = 1;

    float foodConsumptionPerCapita = 1;
    int squareKmPerFarm = 7;
    int buildingScaler = 100;


    //Global set properties
    float inflation = 1f;

    //General Properties
    public GameObject owner;
    public float population;
    public float tradePower;
    public bool isCoastal;
    public int landInSquareKm;
    public float forestedLandInSquareKm;
    public int oreUnmined;
    public string oreType;
    public bool isSeatOfBishop = false;

    //Stocks
    public float silverInDenari = 200000000;
    public int oreIron;
    public int preciousMetals;
    public int metal;
    public int wood;
    public int metalGoods;
    public int food;
    public int woodGoods;
    public int jewelleryGoods;


    //Trade Optimizers
    int idealWood = 1000; //test
    int idealOreIron;
    int idealFinishedGoods;
    int idealArms;


    float requestingSilver;


    //Trade Orders
    public int tradeFood;
    public int tradeWood;
    public int tradeOreIron;
    public int tradePreciousMetals;
    public int tradeMetal;
    public int tradeWoodGoods;
    public int tradeMetalGoods;
    public int tradeJewelleryGoods;


    //Tech
    public float farmingTech = 1;
    public float industrialTech = 1;
    public float miningTech = 1;
    public float navalTech = 1;
    public float warfareTech = 1;
    public float foodTechAverage;

    //Buildings
    public int farms = 0;
    public int docks = 0;
    public int mines = 0;
    public int forges = 0;
    public int lumberMills = 0;

    public int fortifications = 0;
    public int castles = 0;
    public int workshops = 0;
    public int churches = 0;
    public int cathedrals = 0;
    public int universities;

    public int marketLevel = 1;
    public int roadLevel = 1;

    //Stats
    public float educatedPopulationFraction;
    public float communalLandFraction;

    //War and boats
    public int boats = 0;
    public int soldiers = 0;

    //Calculation data
    int foodDeficit;
    int woodDeficit;
    string tradeGood;
    bool isInFamine;
    int citySizeInSquareKm;
    public float peopleToUse;
    public region parentRegion;
    public subcontinent parentSubcontinent;
    public continent parentContinent;


    //Population currently rested
    public float unusedPopulation;

    //--------------------
    //Actions
    //--------------------

    int produceGood(float popToUse, int numberOfBuildings, float techLevel) {
        //Check to make sure this is still possible
        if (unusedPopulation < popToUse) {
            popToUse = unusedPopulation;
        }
        if (numberOfBuildings * buildingScaler < popToUse)
        {
            popToUse = numberOfBuildings * buildingScaler;
        }
        //Convert unused population to goods
        unusedPopulation -= popToUse;
        float produced = popToUse * (1 + techLevel / 10);
        return Mathf.FloorToInt(produced);
    }

    string evaluateTradeGood()
    {
        //This code is fucked
        if (tradeWoodGoods < tradeMetalGoods)
        {
            if (tradeWoodGoods < tradeJewelleryGoods)
            {
                return "woodGoods";
            }
            else
            {
                return "jewelleryGoods";
            }
        }
        else
        {
            if (tradeMetalGoods < tradeJewelleryGoods)
            {
                return "metalGoods";
            }
            else
            {
                return "jewelleryGoods";
            }
        }
    }

    void attemptToBuild(string name)
    {
        if (name == "farm")
        {
            if (silverInDenari > farmCost * inflation)
            {
                silverInDenari = silverInDenari - farmCost * inflation;
                farms = farms + 1;
                parentRegion.regionalMerchantFunds = parentRegion.regionalMerchantFunds + farmCost * inflation;
            }
        }
        if (name == "lumberMill")
        {
            if (silverInDenari > lumberMillCost  * inflation)
            {
                silverInDenari = silverInDenari - lumberMillCost  * inflation;
                lumberMills = lumberMills + 1;
                parentRegion.regionalMerchantFunds = parentRegion.regionalMerchantFunds + lumberMillCost * inflation;
            }
        }
        if (name == "dock")
        {
            if (silverInDenari > dockCost * inflation)
            {
                silverInDenari = silverInDenari - dockCost * inflation;
                docks = docks + 1;
                parentRegion.regionalMerchantFunds = parentRegion.regionalMerchantFunds + dockCost * inflation;
            }
        }
        if (name == "church")
        {
            if (silverInDenari > churchCost * inflation)
            {
                silverInDenari = silverInDenari - churchCost * inflation;
                churches = churches + 1;
                parentRegion.regionalMerchantFunds = parentRegion.regionalMerchantFunds + churchCost * inflation;
            }
        }
        if (name == "cathedral")
        {
            if (silverInDenari > cathedralCost * inflation)
            {
                silverInDenari = silverInDenari - cathedralCost * inflation;
                cathedrals = cathedrals + 1;
                parentRegion.regionalMerchantFunds = parentRegion.regionalMerchantFunds + cathedralCost * inflation;
            }
        }
        if (name == "workshop")
        {
            if (silverInDenari > workshopCost * inflation)
            {
                silverInDenari = silverInDenari - workshopCost * inflation;
                workshops = workshops + 1;
                parentRegion.regionalMerchantFunds = parentRegion.regionalMerchantFunds + workshopCost * inflation;
            }
        }
        if (name == "mine")
        {
            if (silverInDenari > mineCost * inflation)
            {
                silverInDenari = silverInDenari - mineCost * inflation;
                mines = mines + 1;
                parentRegion.regionalMerchantFunds = parentRegion.regionalMerchantFunds + mineCost * inflation;
            }
        }
    }

    //---------------
    //Forced Actions
    //---------------

    void growPopulation()
    {
        population = population * 1.00125f;
    }

    void growForests()
    {
        if (forestedLandInSquareKm < landInSquareKm & forestedLandInSquareKm < +squareKmPerFarm * farms + citySizeInSquareKm)
        {
            forestedLandInSquareKm = forestedLandInSquareKm  * 1.0125f; //This number is different on purpose
        }
        else if (forestedLandInSquareKm > landInSquareKm + squareKmPerFarm * farms + citySizeInSquareKm)
        {
            forestedLandInSquareKm = landInSquareKm - (squareKmPerFarm * farms + citySizeInSquareKm);
        }
    }

    //-----------------------
    //Take Actions
    //-----------------------
    void takeActions()
    {
        foodDeficit = 0;
        food = 0;
        tradeFood = 0;
        tradeWood = 0;
        inflation = parentContinent.inflation;
        woodDeficit = (idealWood - wood);

        //Do production
        citySizeInSquareKm = (workshops + cathedrals + churches + universities) / 4;
        unusedPopulation = population;
        int foodProducers;
        foodDeficit = (-1) * (Mathf.FloorToInt(food - population * foodConsumptionPerCapita));

        if (foodDeficit > 0)
        {
            if (isCoastal == true)
            {
                foodTechAverage = (navalTech + farmingTech) / 2f;
                foodProducers = farms + docks;
            }
            else
            {
                foodTechAverage = farmingTech;
                foodProducers = farms;
            }

            peopleToUse = Mathf.Clamp(Mathf.Clamp(foodDeficit / (1 + (foodTechAverage / 10)), 0f, foodProducers * buildingScaler), 0f, unusedPopulation);
            food = food + produceGood(peopleToUse, foodProducers, foodTechAverage);

            if (foodDeficit - food > 0 & unusedPopulation > 0)
            {
                if (farms < (landInSquareKm / squareKmPerFarm) - citySizeInSquareKm - forestedLandInSquareKm)
                {
                    if (isCoastal == true & foodProducers - farms < farms)
                    {
                        attemptToBuild("dock");
                    }
                    else
                    {
                        attemptToBuild("farm");
                    }
                }
                else
                {
                    tradeFood = (-1) * (foodDeficit);
                }
            }
        }
        else
        {
            tradeFood =  (-1) * (foodDeficit);
        }

        //Workshops, cathedrals, churches, and universities don't do anything yet.

        if (population / 1000 > workshops)
        {
            attemptToBuild("workshop");
        }

        if (population / 3000 > churches)
        {
            attemptToBuild("church");
        }

        if (population / 10000 > cathedrals & cathedrals < 1 & isSeatOfBishop == true)
        {
            attemptToBuild("cathedral");
        }


        if (unusedPopulation > 0)
        {
            if (oreUnmined > 0 & mines > 0)
            {
                peopleToUse = Mathf.Clamp(Mathf.Clamp(Mathf.Clamp(1000000000000, 0f, mines * buildingScaler), 0f, unusedPopulation), 0f, mines * buildingScaler);

                int produced = produceGood(peopleToUse, mines, miningTech);
                if (produced > oreUnmined)
                {
                    produced = oreUnmined;
                }
                oreUnmined = oreUnmined - produced;
                if (oreType == "iron")
                {
                    oreIron = oreIron + produced;
                }
                if (oreType == "silver")
                {
                    silverInDenari = silverInDenari + produced *silverMod;
                    parentContinent.totalSilverInDenari = parentContinent.totalSilverInDenari + produced * silverMod;
                }
            }

            if (oreUnmined > 0 & unusedPopulation > 50)
            {
                if (oreUnmined - (mines * 1000) > 0)
                {
                    attemptToBuild("mine");
                }
            }

            else if (woodDeficit >  0)
            {
                peopleToUse = Mathf.Clamp(Mathf.Clamp(Mathf.Clamp(woodDeficit, 0f, lumberMills * buildingScaler), 0f, unusedPopulation), 0f, lumberMills*buildingScaler);
                wood = wood + produceGood(peopleToUse, lumberMills, 0);
            }
            if (woodDeficit - wood > 0 & unusedPopulation > 50)
            {
                if (forestedLandInSquareKm - (lumberMills + 1) > 0)
                {
                    attemptToBuild("lumberMill");
                }
            }

        }
       
        wood = wood + produceGood(unusedPopulation, lumberMills, 0);
        tradeWood = (-1) * (woodDeficit);
            


        //Do forced actions
        growPopulation();
        growForests();
        foodDeficit = foodDeficit - food;
        if (foodDeficit > (population * foodConsumptionPerCapita) / 20)
        {
            population = population * 0.95f;
            isInFamine = true;
        }
        else
        {
            isInFamine = false;
        }
        tradeGood = evaluateTradeGood();
    }


    void Start()
    {
        parentRegion = gameObject.transform.parent.GetComponent<region>();
        parentSubcontinent = gameObject.transform.parent.parent.GetComponent<subcontinent>();
        parentContinent = gameObject.transform.parent.parent.parent.GetComponent<continent>();
        parentContinent.initialTotalSilverInDenari = parentContinent.initialTotalSilverInDenari + silverInDenari;
        InvokeRepeating("takeActions",0f, 3f);
    }




}
