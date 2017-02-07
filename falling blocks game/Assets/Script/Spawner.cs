using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;
    private Vector2 screenHalfSizeWorldUnits;
    private float nextSpawnTime;
    public bool isStartGame;
    // Use this for initialization
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize,
            Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStartGame) return;
        //calculater the time to create new block gameobject
        if (!(Time.time > nextSpawnTime)) return;
        //calculater for next time
        float secondsBetweenSpawns =
            Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x,Difficulty.GetDifficultyPercent());
        nextSpawnTime = Time.time + secondsBetweenSpawns;
        //calculater random size for new block object
        float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
        //calculater random angle for new block object
        float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
        //calculater random posistion for new block object
        Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x),
            screenHalfSizeWorldUnits.y + spawnSize );
        //create the new block gameobject
        GameObject newBlock = Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(spawnAngle * Vector3.forward)) as GameObject;
        //setup the new block gameobject size
        newBlock.transform.localScale = Vector3.one * spawnSize;
    }
}
