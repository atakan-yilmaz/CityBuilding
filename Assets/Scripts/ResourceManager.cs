using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [Header("Resources")]
    [Space(8)]

    //SETS THE MAX AMOUNT OF RESOURCESS
    public int maxWood;
    int wood = 0;

    public int maxStone;
    int stone = 0;

    public int maxPremiumCurrency;
    int premium = 0;

    public int maxStandard;
    int standard = 0;


    /// <summary>
    /// ADDS MORE WOOD TO THE INVENTORY
    /// </summary>
    /// <param name="amount">AMOUNT TO ADD DIRECTLY TO OUR EXISTING WOOD</param>
    public void AddWood(int amount)
    {
        wood += amount;
    }

    /// <summary>
    /// ADDS MORE STONE TO THE INVENTORY
    /// </summary>
    /// <param name="amount">AMOUNT TO ADD DIRECTLY TO OUR EXISTING STONE</param>
    public void AddStone(int amount)
    {
        stone += amount;
    }

    /// <summary>
    /// ADDS MORE PREMIUM TO THE INVENTORY
    /// </summary>
    /// <param name="amount">AMOUNT TO ADD DIRECTLY TO OUR EXISTING PREMIUM</param>
    public void AddPremium(int amount)
    {
        premium += amount;
    }

    /// <summary>
    /// ADDS MORE STANDARD TO THE INVENTORY
    /// </summary>
    /// <param name="amount">AMOUNT TO ADD DIRECTLY TO OUR EXISTING STANDARD</param>
    public void AddStandard(int amount)
    {
        standard += amount;
    }
}