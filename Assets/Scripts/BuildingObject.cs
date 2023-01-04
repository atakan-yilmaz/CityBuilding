using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingObject : MonoBehaviour
{
    public BuildManager data;

    [Header("Resource Generation")]
    [Space(8)]

    //THIS WILL BE THE RESOURCE THAT HAS BEED CREATED BY THIS BUILDING 
    public float resource = 0;

    public int resourceLimit = 100;

    //RESOURCE GENERATE SPEED
    public float generationSpeed = 5;

    Coroutine buildingBehaviour;

    private void Start()
    {
        if (data.resourceType == BuildManager.ResourceType.Standard || data.resourceType == BuildManager.ResourceType.Premium)
            buildingBehaviour = StartCoroutine(CreateResource());

        if (data.resourceType == BuildManager.ResourceType.Storage)
        {
            Debug.Log("increase build");
            IncreaseMaxStorage();
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

            yield return null;
        }
    }
}