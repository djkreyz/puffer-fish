using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [Header("Configuration parameters")]
    [SerializeField] Renderer player;
    [SerializeField] Renderer bubbleCenter;
    [SerializeField] Transform circle;

    [Header("Bubble")]
    float bubbleMagnitude;
    [SerializeField] [Range(1, 2)] float maxRangeDistruction;
    [SerializeField] [Range(1, 2)] float minRangeDistruction;

    [Header("Bubble Spawn Boundaries")]
    [SerializeField] float padding = 0.1f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    [Header("Bubble Random Spawn")]
    float randomX;
    float randomY;
    Vector3 newRandomPos;

    [Header("Circle Scale Magnitude")]
    float actualCircleLocalScaleMagnitude;
    bool isIntersects = false;



    void Start()
    {
        bubbleMagnitude = transform.localScale.magnitude + maxRangeDistruction;

        //Set up bubble spawners
        SetUpBubbleSpawnBoundaries();
    }

    void Update()
    {
        //Every frame checks circle scale magnitude 
        ActualCircleLocalScaleMagnitude();

        //Checks if the player intersect bubble 
        Intersecting();

        //On mouse up bubble will be destroyed
        OnMouseUpDestroy();
    }

    private void OnMouseUpDestroy()
    {

        if (Input.GetMouseButtonUp(0))
        {
            //We can clearly see actual circle local scale magnitude after we release left mouse button
            Debug.Log(actualCircleLocalScaleMagnitude);
            Debug.Log(isIntersects);
            //If player intersects and hit min or max range distruction bubble will be destroyed
            if (isIntersects == true && (ActualCircleLocalScaleMagnitude() > minRangeDistruction) && (ActualCircleLocalScaleMagnitude() < bubbleMagnitude))
            {
                gameObject.transform.position = SetUpNewRandomPosition();
            }
        }
    }
    private float ActualCircleLocalScaleMagnitude()
    {
        actualCircleLocalScaleMagnitude = circle.transform.localScale.magnitude;
        return actualCircleLocalScaleMagnitude;
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
        randomX = Random.Range(xMin, xMax);
        randomY = Random.Range(yMin, yMax);
        newRandomPos = new Vector3(randomX, randomY, transform.position.z);

        return newRandomPos;
    }
}
