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
        buildingBehaviour = StartCoroutine(CreateResource());    
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