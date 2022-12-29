using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    public ObstacleType obstacleType;
    public int ResourceAmount = 10;


    /// <summary>
    /// THIS IS A METHOD THAT IT IS CALLED WHENEVER THE ITEM HAS BEED CLICKED OR TAPPED
    /// </summary>
    private void OnMouseDown()
    {
        //OnClick Event

        //CALL DIRECTLY THE METHOD THAT ADDS THE RESOURCE
        switch (obstacleType)
        {
            case ObstacleType.Stone:
                ResourceManager.Instance.AddStone(ResourceAmount);
                break;
            case ObstacleType.Wood:
                ResourceManager.Instance.AddWood(ResourceAmount);
                break;
        }
    }

    public enum ObstacleType
    {
        Stone,
        Wood
    }
}