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

    //FLOOR
    public float yPadding = 0;

    public StorageType storageType = StorageType.None;

    //TYPE OF FUNCTIONALITY OF THE BUILDING 
    public ResourceType resourceType = ResourceType.None;

    //[HideInInspector]
    public BuildingObject refOfBuilding;

    public enum ResourceType
    {
        None,
        Standard,
        Premium,
        Storage
    }

    public enum StorageType
    {
        None,
        Wood,
        Stone
    }
}