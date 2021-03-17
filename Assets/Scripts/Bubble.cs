﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [Header("Configuration parameters")]
    [SerializeField] Renderer player;
    [SerializeField] Renderer bubbleCenter;
    [SerializeField] Transform circle;

    [Header("Range Destruction")]
    [SerializeField]  float maxRangeDestruction;
    [SerializeField]  float minRangeDestruction;
    //Random magnitude
    float bubbleLocalScaleX;
    float randMagXY;
    Vector3 newRandomMag;

    [Header("Spawn Boundaries")]
    [SerializeField] float padding = 0.1f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    [Header("Player Health")]
    [SerializeField] GameObject playerGameObject;
    [SerializeField] float playerHealth = 100f;
    [SerializeField] float healthDecreaseRate = 1f;
    [SerializeField] float healthIncreaseRate = 20f;

    //Random position
    float randomPosX;
    float randomPosY;
    Vector3 newRandomPos;

    //Circle Scale X
    float actualCircleLocalScaleX;
    bool isIntersects = false;

    //Bubble Position
    Vector3 currentBubblePos;
    bool isBubblePosChange;

    void Start()
    {
        Debug.Log(transform.localScale.magnitude);
        //Set up bubble spawners
        SetUpBubbleSpawnBoundaries();

        currentBubblePos = new Vector3(transform.position.x, transform.position.y);
    }

    void Update()
    {
        //Every frame checks circle scale magnitude 
        ActualCircleLocalScaleMagnitude();

        //Checks if the player intersect bubble 
        Intersecting();

        //On mouse up bubble will be destroyed
        OnMouseUpDestroy();

        //After player health scaling 
        PlayerHealthScaling();

        //Min and max range destruction of bubble (Count only X, because Y is same number.
        //Also this is the only way to compare bubble and circle size)
        MinAndMaxRangeDestruction();

        //Destroys player gameobject after his HP reach 0
        DestroyPlayer();
    }

    private void OnMouseUpDestroy()
    {

        if (Input.GetMouseButtonUp(0))
        {
            //We can clearly see actual circle local scale magnitude after we release left mouse button
            Debug.Log(actualCircleLocalScaleX);
            Debug.Log(bubbleLocalScaleX);
            Debug.Log(isIntersects);
            //Debug.Log(isBubbleDestroyed);
            //If player intersects and hit min or max range distruction bubble will be destroyed
            if (isIntersects == true && (ActualCircleLocalScaleMagnitude() > minRangeDestruction) && (ActualCircleLocalScaleMagnitude() < maxRangeDestruction))
            {
                gameObject.transform.position = SetUpNewRandomPosition();

                
                Debug.Log("max" + maxRangeDestruction);
                SetUpNewRandomMagnitude();
                Debug.Log("min" + minRangeDestruction);
            }
        }
    }
    private float ActualCircleLocalScaleMagnitude()
    {
        actualCircleLocalScaleX = circle.transform.localScale.x;
        return actualCircleLocalScaleX;
    }

    private void Intersecting()
    {
        if (player.bounds.Intersects(bubbleCenter.bounds))
        {
            isIntersects = true;
        }
        else
        {
            isIntersects = false;
        }
    }

    private void SetUpBubbleSpawnBoundaries()
    {
        //Convert main camera to 2D world
        // x & y (0,1) always
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private Vector3 SetUpNewRandomPosition()
    {
        randomPosX = Random.Range(xMin, xMax);
        randomPosY = Random.Range(yMin, yMax);
        newRandomPos = new Vector3(randomPosX, randomPosY, transform.position.z);

        return newRandomPos;
    } 

    private void SetUpNewRandomMagnitude()
    {
        randMagXY = Random.Range(2f, 3f);
        newRandomMag = new Vector3(randMagXY, randMagXY, transform.position.z);

        gameObject.transform.localScale = newRandomMag;
    }

    public bool PlayerHealthScaling()
    {
        if (currentBubblePos != newRandomPos)
        {
            currentBubblePos = newRandomPos;
            playerHealth += healthIncreaseRate;
            isBubblePosChange = true;
        }
        else
        {
            playerHealth -= healthDecreaseRate * Time.deltaTime;
            isBubblePosChange = false;
            //Debug.Log(playerHealth);
        }
        return isBubblePosChange;
    }

    private void DestroyPlayer()
    {
        if (playerHealth <= 0)
        {
            Destroy(playerGameObject);
        }
    }
        
    private void MinAndMaxRangeDestruction()
    {
        //Flexible min and max for new random size
        bubbleLocalScaleX = transform.localScale.x;

        minRangeDestruction = bubbleLocalScaleX - 0.5f;
        maxRangeDestruction = bubbleLocalScaleX;
    }

}
