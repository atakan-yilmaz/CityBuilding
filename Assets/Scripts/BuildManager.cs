using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BuildManager
{
    //REFERENCE THE EXACT TYPE OF BUILDING
    public int buildingID;

    //WIDTH X AXIS THAT WILL BE USED INSIDE THE GRID
    public int width = 0;

    //LENGTH Z AXIS THAT WILL BE USED INSIDE THE GRID
    public int length = 0;

    //VISUAL
    public GameObject buildingModel;

    //TYPE OF FUNCTIONALITY OF THE BUILDING 
    public ResourceType resourceType = ResourceType.None;

    public enum ResourceType
    {
        None,
        Standard,
        Premium
    }
}