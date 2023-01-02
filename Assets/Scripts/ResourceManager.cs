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

    public static ResourceManager Instance;

    public bool debugBool = false;

    #region ENCAPSULATION
    public int Wood { get => wood; set => wood = value; }
    public int Stone { get => stone; set => stone = value; }
    public int Premium { get => premium; set => premium = value; }
    public int Standard { get => standard; set => standard = value; }
    #endregion

    private void Awake()
    {
        Instance = this;   
    }

    private void Update()
    {
        if (debugBool)
        {
            debugBool = false; 
        }
    }

    #region Resources
    /// <summary>
    /// ADDS MORE WOOD TO THE INVENTORY
    /// </summary>
    /// <param name="amount">AMOUNT TO ADD DIRECTLY TO OUR EXISTING WOOD</param>
    public bool AddWood(int amount)
    {
        if ((Wood + amount) <= maxWood)
        {
            Wood += amount;

            //UPDATES THE CORRESPONDING UI
            UIManager.Instance.UpdateWoodUI(Wood, maxWood);

            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// ADDS MORE STONE TO THE INVENTORY
    /// </summary>
    /// <param name="amount">AMOUNT TO ADD DIRECTLY TO OUR EXISTING STONE</param>
    public bool AddStone(int amount)
    {
        if ((Stone + amount) <= maxStone)
        {
            Stone += amount;

            //UPDATES THE CORRESPONDING UI
            UIManager.Instance.UpdateStoneUI(Stone, maxStone);

            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// ADDS MORE PREMIUM TO THE INVENTORY
    /// </summary>
    /// <param name="amount">AMOUNT TO ADD DIRECTLY TO OUR EXISTING PREMIUM</param>
    public bool AddPremium(int amount)
    {
        if ((Premium + amount) <= maxPremiumCurrency)
        {
            Premium += amount;

            //UPDATES THE CORRESPONDING UI
            UIManager.Instance.UpdatePremiumUI(Premium, maxPremiumCurrency);

            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// ADDS MORE STANDARD TO THE INVENTORY
    /// </summary>
    /// <param name="amount">AMOUNT TO ADD DIRECTLY TO OUR EXISTING STANDARD</param>
    public bool AddStandard(int amount)
    {
        if ((Standard + amount) <= maxStandard)
        {
            Standard += amount;

            //UPDATES THE CORRESPONDING UI
            UIManager.Instance.UpdateStandardUI(Standard, maxStandard);

            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion
}