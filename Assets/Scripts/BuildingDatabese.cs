using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDatabese : MonoBehaviour
{
    public List<BuildManager> buildingDatabese = new List<BuildManager>();

    public static BuildingDatabese Instance;

    private void Awake()
    {
        Instance = this;
    }
}