using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuration Parameters")]
    [SerializeField] GameObject bottle;

    [Header("Spawn Boundaries")]
    [SerializeField] float padding = 1;
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    //Random Spawn
    float xRandom;
    Vector3 bottlePosition;
    bool isSpawned = false;

    //Timer Sec
    float countSec;
    float seconds;
    private void Start()
    {
        SetUpEnemySpawnBoundaries();
    }

    private void Update()
    {
        RandomXPosition();
        bottlePosition = new Vector3(xRandom, yMax);
        TimerCountSec();
        if(seconds == 10 && isSpawned == false)
        {
            isSpawned = true;
            Instantiate(bottle, bottlePosition, Quaternion.identity);
        }
        if(seconds == 11)
        {
            isSpawned = false;
        }
        if(seconds == 15 && isSpawned == false)
        {
            isSpawned = true;
            Instantiate(bottle, bottlePosition, Quaternion.identity);
        }
    }

    private void RandomXPosition()
    {
        xRandom = Random.Range(xMin, xMax);
    }

    private void SetUpEnemySpawnBoundaries()
    {
        //Convert main camera to 2D world
        // x & y (0,1) always
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    private void TimerCountSec()
    {
        countSec += Time.deltaTime;
        seconds = Mathf.FloorToInt(countSec % 60);
    }
}
