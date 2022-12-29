using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Builder")]
    [Space(8)]

    public GameObject tilePrefab;

    public int levelWidth;
    public int levelLength;
    public Transform tilesHolder;
    public float tileSize = 1f;


    [Header("Resources")]
    [Space(8)]

    public GameObject woodPrefab;
    public GameObject stonePrefab;

    [Range(0, 1)]
    public float obstacleChance = 0.3f;

    public int xBounds = 3;
    public int zBounds = 3;


    private void Start()
    {
        CreateLevel();
    }

    public void CreateLevel()
    {
        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                TileObject spawnedTile =  SpawnTile(x * tileSize, z * tileSize);

                if (x < xBounds)
                {
                    //SPAWN THE OBSTACLE IN THERE
                    spawnedTile.data.SetOccupied(TileManager.ObstacleType.Resource);
                }

                if (z < zBounds)
                {
                    //SPAWN THE OBSTACLE IN THERE
                }
            }
        }
    }

    //SPAWNS AND RETURNS A "tileObject"
    TileObject SpawnTile(float xPos, float zPos)
    {
        GameObject tmpTile = Instantiate(tilePrefab);

        tmpTile.transform.position = new Vector3(xPos, 0, zPos);
        tmpTile.transform.SetParent(tilesHolder);

        return tmpTile.GetComponent<TileObject>();
    }
}