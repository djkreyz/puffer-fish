using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuration Parameters")]
    [SerializeField] List<GameObject> crab;
    [SerializeField] GameObject bottle;
    [SerializeField] GameObject stone;
    [SerializeField] GameObject redCircle;
    int crabIndex;

    [Header("Spawn Boundaries")]
    [SerializeField] float padding = 1;
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    //Random Spawn
    float xRandom;
    float yRandom;
    Vector3 bottlePosition;
    Vector3 stonePosition;
    Vector3 crabPosition;
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
        RandomYPosition();
        //-1 because circle spawn half outside the game
        bottlePosition = new Vector3(xRandom, yMax - 1);

        stonePosition = new Vector3(xRandom, yMax - 1);

        crabPosition = new Vector3(xMin, yRandom - 1);

        TimerCountSec();
        //Loop that spawn enemies
        if (seconds == 5 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnStone());
        }
        if (seconds == 6)
        {
            isSpawned = false;
        }
        if (seconds == 10 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnBottle());
        }
        if(seconds == 11)
        {
            isSpawned = false;
        }
        if(seconds == 15 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnBottle());
            StartCoroutine(SpawnCrab());
        }
        if (seconds == 16)
        {
            isSpawned = false;
        }
        if (seconds == 17 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnBottle());
        }
        if (seconds == 18)
        {
            isSpawned = false;
        }
        if (seconds == 20 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnCrab());
        }
        if (seconds == 21)
        {
            isSpawned = false;
        }
        if (seconds == 25 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnStone());
        }
        if (seconds == 26)
        {
            isSpawned = false;
        }
        if (seconds == 27 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnBottle());
        }
        if (seconds == 28)
        {
            isSpawned = false;
        }
        if (seconds == 29 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnBottle());
        }
        if (seconds == 30)
        {
            isSpawned = false;
        }
        if (seconds == 34 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnStone());
            StartCoroutine(SpawnCrab());
        }
        if (seconds == 35)
        {
            isSpawned = false;
        }
        if (seconds == 39 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnBottle());
        }
        if (seconds == 40)
        {
            isSpawned = false;
        }
        if (seconds == 41 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnBottle());
        }
        if (seconds == 42)
        {
            isSpawned = false;
        }
        if (seconds == 45 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnCrab());
        }
        if (seconds == 46)
        {
            isSpawned = false;
        }
        if (seconds == 50 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnStone());
        }
        if (seconds == 51)
        {
            isSpawned = false;
        }
        if (seconds == 52 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnBottle());
        }
        if (seconds == 53)
        {
            isSpawned = false;
        }
        if (seconds == 57 && isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnCrab());
        }
        if (seconds == 58)
        {
            isSpawned = false;
        }

    }

    private void RandomXPosition()
    {
        xRandom = Random.Range(xMin, xMax);
    }

    private void RandomYPosition()
    {
        yRandom = Random.Range(yMin, yMax);
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

    IEnumerator SpawnBottle()
    {
        //Instantiate red circle with animation than bottle
        GameObject cloneRedCircle = Instantiate(redCircle, bottlePosition, Quaternion.identity);
        Vector3 positionCloneRedCircle = cloneRedCircle.transform.position;
        yield return new WaitForSeconds(1);
        Instantiate(bottle, positionCloneRedCircle, Quaternion.identity);
        Destroy(cloneRedCircle);
    }

    IEnumerator SpawnStone()
    {
        //Instantiate red circle with animation than bottle
        GameObject cloneRedCircle = Instantiate(redCircle, bottlePosition, Quaternion.identity);
        Vector3 positionCloneRedCircle = cloneRedCircle.transform.position;
        yield return new WaitForSeconds(1);
        Instantiate(stone, positionCloneRedCircle, Quaternion.identity);
        Destroy(cloneRedCircle);
    }

    IEnumerator SpawnCrab()
    {
        //Instantiate red circle with animation than crab
        GameObject cloneRedCircle = Instantiate(redCircle, crabPosition, Quaternion.identity);
        Vector3 positionCloneRedCircle = cloneRedCircle.transform.position;
        yield return new WaitForSeconds(1);
        crabIndex = Random.Range(0, crab.Count);
        Instantiate(crab[crabIndex], positionCloneRedCircle, Quaternion.identity);
        Debug.Log(crabIndex);
        Destroy(cloneRedCircle);
    }

}
