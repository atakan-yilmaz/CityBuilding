using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingObject : MonoBehaviour
{
    public BuildManager data;

    [Header("Resource Generation")]
    [Space(8)]

    //THIS WILL BE THE RESOURCE THAT HAS BEED CREATED BY THIS BUILDING 
    public float resource = 0;

    public int resourceLimit = 100;

    //RESOURCE GENERATE SPEED
    public float generationSpeed = 0;

    [Header("UI")]
    [Space(8)]
    public Slider progressSlider;
    public GameObject canvasObject;

    Coroutine buildingBehaviour;

    private void Start()
    {
        if (data.resourceType == BuildManager.ResourceType.Standard || data.resourceType == BuildManager.ResourceType.Premium)
            buildingBehaviour = StartCoroutine(CreateResource());

        if (data.resourceType == BuildManager.ResourceType.Storage)
        {
            Debug.Log("increase build");
            canvasObject.SetActive(false);
        }
    }
    
    private void OnMouseDown()
    {
        if (data.resourceType == BuildManager.ResourceType.Storage)
            return;

        switch (data.resourceType)
        {
            case BuildManager.ResourceType.Standard:
                ResourceManager.Instance.AddStandard((int)resource);
                break;

            case BuildManager.ResourceType.Premium:
                ResourceManager.Instance.AddPremium((int)resource);
                break;
        }

        EmptyResource();
    }

    void EmptyResource()
    {
        resource = 0;
    }

    void IncreaseMaxStorage()
    {
        switch (data.storageType)
        {
            case BuildManager.StorageType.Wood:
                ResourceManager.Instance.IncreaseMaxWood((int)resource);
                break;
            case BuildManager.StorageType.Stone:
                ResourceManager.Instance.IncreaseMaxStone((int)resource);
                break;
        }
    }

    IEnumerator CreateResource()
    {
        //RESOURCES INFINITELY
        while (true)
        {
            if (resource < resourceLimit)
            {
                resource += generationSpeed * Time.deltaTime;
            }
            else
            {
                resource = resourceLimit;
            }

            UpdateUI(resource, resourceLimit);

            yield return null;
        }
    }

    public void UpdateUI(float current, float maxValue)
    {
        progressSlider.value = current;
        progressSlider.maxValue = maxValue;
    }
}