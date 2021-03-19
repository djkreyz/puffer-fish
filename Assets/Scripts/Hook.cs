using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    float actualRopeSize;
    float ropeTimer;

    void Start()
    {
       
    }

    
    void Update()
    {
        RopeMovement();
    }

    private void RopeMovement()
    {
        ropeTimer += 0.1f;
        Debug.Log(ropeTimer);


        if (ropeTimer <= 100f)
        {
            GoDown();
        }
        else
        {
            GoUp();
        }
    }

    private void GoDown()
    {
        gameObject.transform.localScale += new Vector3(0, 1f, 0) * Time.deltaTime;
    }

    private void GoUp()
    {
        actualRopeSize = gameObject.transform.localScale.y;

        gameObject.transform.localScale -= new Vector3(0, 2.5f, 0) * Time.deltaTime;
        if (actualRopeSize <= 0)
        {
            Destroy(gameObject);
        }
    }
}
