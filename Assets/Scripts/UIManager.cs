using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [Header("References")]
    [Space(8)]
    //REFERENCES FOR CONTAINERS
    public StandardUIReferences woodUI;
    public StandardUIReferences stoneUI;
    public StandardUIReferences standardUI;
    public StandardUIReferences premiumUI;


    //INSTANCE HANDLING FOR SINGLETON
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateAll();
    }

    /// <summary>
    /// UPDATES THE WOOD UI
    /// </summary>
    /// <param name="maxAmount">SETS THE MAXIMUM AMOUNT OF THE SLIDER AND TEXT</param>
    /// <param name="currentAmount">SETS THE CURRENT AMOUNT OF THE SLIDER AND TEXT</param>
    public void UpdateWoodUI(int currentAmount, int maxAmount)
    {
        //SET THE TEXT
        woodUI.currentUI.text = currentAmount.ToString();
        woodUI.maxUI.text = "MAX: " + maxAmount.ToString();

        //SET THE SLIDER
        woodUI.slider.maxValue = maxAmount;
        woodUI.slider.value = currentAmount;
    }

    /// <summary>
    /// UPDATES THE PREMIUM UI
    /// </summary>
    /// <param name="maxAmount">SETS THE MAXIMUM AMOUNT OF THE SLIDER AND TEXT</param>
    /// <param name="currentAmount">SETS THE CURRENT AMOUNT OF THE SLIDER AND TEXT</param>
    public void UpdatePremiumUI(int currentAmount, int maxAmount)
    {
        //SET THE TEXT
        premiumUI.currentUI.text = currentAmount.ToString();
        premiumUI.maxUI.text = "MAX: " + maxAmount.ToString();

        //SET THE SLIDER
        premiumUI.slider.maxValue = maxAmount;
        premiumUI.slider.value = currentAmount;
    }

    /// <summary>
    /// UPDATES THE STONE UI
    /// </summary>
    /// <param name="maxAmount">SETS THE MAXIMUM AMOUNT OF THE SLIDER AND TEXT</param>
    /// <param name="currentAmount">SETS THE CURRENT AMOUNT OF THE SLIDER AND TEXT</param>
    public void UpdateStoneUI(int currentAmount, int maxAmount)
    {
        //SET THE TEXT
        stoneUI.currentUI.text = currentAmount.ToString();
        stoneUI.maxUI.text = "MAX: " + maxAmount.ToString();

        //SET THE SLIDER
        stoneUI.slider.maxValue = maxAmount;
        stoneUI.slider.value = currentAmount;
    }

    /// <summary>
    /// UPDATES THE STANDARD UI
    /// </summary>
    /// <param name="maxAmount">SETS THE MAXIMUM AMOUNT OF THE SLIDER AND TEXT</param>
    /// <param name="currentAmount">SETS THE CURRENT AMOUNT OF THE SLIDER AND TEXT</param>
    public void UpdateStandardUI(int currentAmount, int maxAmount)
    {
        //SET THE TEXT
        standardUI.currentUI.text = currentAmount.ToString();
        standardUI.maxUI.text = "MAX: " + maxAmount.ToString();

        //SET THE SLIDER
        standardUI.slider.maxValue = maxAmount;
        standardUI.slider.value = currentAmount;
    }

    void UpdateAll()
    {
        UpdateStoneUI(ResourceManager.Instance.Stone, ResourceManager.Instance.maxStone);
        UpdateWoodUI(ResourceManager.Instance.Wood, ResourceManager.Instance.maxWood);
        UpdatePremiumUI(ResourceManager.Instance.Premium, ResourceManager.Instance.maxPremiumCurrency);
        UpdateStandardUI(ResourceManager.Instance.Standard, ResourceManager.Instance.maxStandard);
    }
}

//MAIN CLASS FOR SETTING UP THE CONTAINER
[System.Serializable]
public class StandardUIReferences
{
    public Slider slider;
    public Text maxUI;
    public Text currentUI;
}