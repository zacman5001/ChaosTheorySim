using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class region : MonoBehaviour {

    public subcontinent parentSubcontinent;
    public continent parentContinent;

    public float regionalMerchantFunds = 24000;
    public float regionalCostWood = 100;
    public float regionalCostFood = 100;
    public int regionalFoodSurplus = 0;
    public int regionalWoodSurplus = 0;

    int netFoodOrders = 0;
    int netWoodOrders = 0;
    int volumeWood = 0;
    int volumeFood = 0;

    List<estate> estates = new List<estate>();
    List<tradeOrder> tradeOrders = new List<tradeOrder>();
    List<estate> estatesInTradeOrder = new List<estate>();

    void trade()
    {
        tradeOrders.Clear();
        estatesInTradeOrder.Clear();
        IEnumerable<estate> query = estates.OrderByDescending(estate => estate.tradePower);
        foreach (estate estate in query)
        {
            estatesInTradeOrder.Add(estate);
        }
        foreach (estate estate in estatesInTradeOrder)
        {
            if (estate.tradeFood != 0)
            {
                tradeOrder order = new tradeOrder();
                order.owner = estate;
                order.amount = estate.tradeFood;
                order.resource = "food";
                order.willingToPay = 0; //test
                tradeOrders.Add(order);
            }
            if (estate.tradeWood != 0)
            {
                tradeOrder order = new tradeOrder();
                order.owner = estate;
                order.amount = estate.tradeWood;
                order.resource = "wood";
                order.willingToPay = 0; //test
                tradeOrders.Add(order);
            }
        }
        foreach (tradeOrder order in tradeOrders)
        {
            if (order.amount > 0)
            {
                if (order.resource == "food" & regionalCostFood * order.amount < regionalMerchantFunds)
                {
                    regionalFoodSurplus = regionalFoodSurplus + order.amount;
                    order.owner.silverInDenari = order.owner.silverInDenari + order.amount * regionalCostFood;
                    order.owner.food = order.owner.food - order.amount;
                    order.owner.tradeFood = 0;
                    regionalMerchantFunds = regionalMerchantFunds - regionalCostFood * order.amount;
                    netFoodOrders = netFoodOrders + order.amount;
                    volumeFood = volumeFood + Mathf.Abs(order.amount);

                }
                if (order.resource == "wood" & regionalCostWood * order.amount < regionalMerchantFunds)
                {
                    regionalWoodSurplus = regionalWoodSurplus + order.amount;
                    order.owner.silverInDenari = order.owner.silverInDenari + order.amount * regionalCostWood;
                    order.owner.wood = order.owner.wood - order.amount;
                    order.owner.tradeWood = 0;
                    regionalMerchantFunds = regionalMerchantFunds - regionalCostFood * order.amount;
                    netWoodOrders = netWoodOrders + order.amount;
                    volumeWood = volumeWood + Mathf.Abs(order.amount);

                }
            }
        }

        foreach (tradeOrder order in tradeOrders)
            if (order.amount < 0)
            {

                {
                    if (order.resource == "food")
                    {
                        if (order.amount * (-1) <= regionalFoodSurplus)
                        {
                            order.owner.food = order.owner.food + order.amount * (-1);
                            regionalFoodSurplus = regionalFoodSurplus - order.amount * (-1);
                            regionalMerchantFunds = regionalMerchantFunds + regionalCostFood * order.amount * (-1);
                        }
                        else
                        {
                            order.owner.food = order.owner.food + regionalFoodSurplus;
                            order.owner.silverInDenari = order.owner.silverInDenari - regionalFoodSurplus * regionalCostFood;
                            regionalMerchantFunds = regionalMerchantFunds + regionalFoodSurplus * regionalCostFood;
                            regionalFoodSurplus = 0;
                        }
                        netFoodOrders = netFoodOrders + order.amount;
                        volumeFood = volumeFood + Mathf.Abs(order.amount);


                    }
                    else if (order.resource == "wood")
                    {
                        {
                            if (order.amount * (-1) <= regionalWoodSurplus)
                            {
                                order.owner.wood = order.owner.wood + (-1) * order.amount;
                                regionalWoodSurplus = regionalWoodSurplus - (-1) * order.amount;
                                regionalMerchantFunds = regionalMerchantFunds + regionalCostFood * (-1) * order.amount;

                            }
                            else
                            {
                                order.owner.wood = order.owner.wood + regionalWoodSurplus;
                                order.owner.silverInDenari = order.owner.silverInDenari - regionalWoodSurplus * regionalCostWood;
                                regionalMerchantFunds = regionalMerchantFunds + regionalWoodSurplus * regionalCostWood;
                                regionalWoodSurplus = 0;
                            }
                        }
                        netWoodOrders = netWoodOrders + order.amount;
                        volumeWood = volumeWood + Mathf.Abs(order.amount);

                    }
                }
            }

        Debug.unityLogger.Log(volumeWood.ToString());
        Debug.unityLogger.Log(netWoodOrders.ToString());
        //regionalCostFood = Mathf.Clamp(regionalCostFood + (volumeFood) / netFoodOrders * (-1), -100000f, 50000f);
        regionalCostWood = Mathf.Clamp(regionalCostWood + (volumeWood) / netWoodOrders * (-1), -100000f, 50000f);
        volumeWood = 0;
        volumeFood = 0;
        netWoodOrders = 0;
        netFoodOrders = 0;
    }
    void Start() {
        foreach (Transform child in transform)
        {
            estates.Add(child.GetComponent<estate>());
        }
        parentSubcontinent = gameObject.transform.parent.GetComponent<subcontinent>();
        parentContinent = gameObject.transform.parent.parent.GetComponent<continent>();
        parentContinent.initialTotalSilverInDenari = parentContinent.initialTotalSilverInDenari + regionalMerchantFunds;
        InvokeRepeating("trade", 0f, 3f);
    }
}
