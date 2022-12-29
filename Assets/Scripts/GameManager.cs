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
    public float tileEndHeight = 1;

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

                if (x < xBounds || z < zBounds || z >= (levelLength - zBounds) || x >= (levelWidth - xBounds))
                {
                    //SPAWN THE OBSTACLE IN THERE
                    spawnedTile.data.StarterTileValue(false);
                }

                if (spawnedTile.data.CanSpawnObstacle)
                {
                    bool spawnObstacle = Random.value <= obstacleChance;

                    if (spawnObstacle)
                    {
                        //HANDLE THE SPAWNING OBSTACLE FUNCTIONALITY
                        //Debug.Log("Spawned obstacle on " + spawnedTile.gameObject.name);

                        //DEBUG (DELETE LATER)
                        //spawnedTile.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

                        spawnedTile.data.SetOccupied(TileManager.ObstacleType.Resource);
                        SpawnObstacle(spawnedTile.transform.position.x, spawnedTile.transform.position.z);
                    }
                }
            }
        }
    }

    /// <summary>
    /// SPAWNS AND RETURNS A tileObject
    /// </summary>
    /// <param name="xPos">X Position inside the world</param>
    /// <param name="zPos">Z Position inside the world</param>
    /// <returns></returns>
    //SPAWNS AND RETURNS A "tileObject"
    TileObject SpawnTile(float xPos, float zPos)
    {
        GameObject tmpTile = Instantiate(tilePrefab);

        tmpTile.transform.position = new Vector3(xPos, 0, zPos);
        tmpTile.transform.SetParent(tilesHolder);

        tmpTile.name = "Tile" + xPos + " - " + zPos;

        return tmpTile.GetComponent<TileObject>();
    }

    /// <summary>
    /// WILL SPAWN A RESOURCE OBSTACLE DIRECTLY IN THE COORDINATES
    /// </summary>
    /// <param name="xPos">X Position of the obstacle</param>
    /// <param name="zPos">Z Position of the obstacle</param>
    public void SpawnObstacle(float xPos, float zPos)
    {
        bool isWood = Random.value <= 0.5f;

        GameObject spawnedObstacle = null;

        //CHECK WHETHER WE SPAWN A WOOD OBSTACLE OR A STONE OBSTACLE
        if (isWood)
        {
            spawnedObstacle = Instantiate(woodPrefab);
        }
        else
        {
            spawnedObstacle = Instantiate(stonePrefab);
        }

        spawnedObstacle.transform.position = new Vector3(xPos, tileEndHeight, zPos);
    }
}