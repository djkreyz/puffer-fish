using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Configuration parameters")]
    [SerializeField] Transform circleObject;

    [Header("Boundaries")]
    [SerializeField] float padding = 0.1f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    [Header("Player")]
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float health = 100f;
    [SerializeField] float healthDecreaseRateInSec = 1f;
    [SerializeField] float healthIncreaseRate = 10f;
    bool isMouseLeftButtonDown = false;

    [Header("Circle")]
    [SerializeField] Vector3 maxCircleLocalScale;
    float maxCirleLocalScaleMagnitude;

    // Start is called before the first frame update
    void Start()
    {
        //Maximum that circle can scaling
        MaxCircleScale();

        //Boundaries player movement
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        //Scaling circle
        CircleScale();

        //Player controls
        PlayerMouseControl();

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseLeftButtonDown = true;
        }
    }

    private void OnMouseUp()
    {
        isMouseLeftButtonDown = false;
    }

    private void CircleScale()
    {
        //Take actual circle magnitude and size it up
        float actualCircleLocalScaleMagnitude = circleObject.transform.localScale.magnitude;
        //We can compare this because 1st variable is magnitude of object and 2d is Vector3.
        //If there were two Vectors3 we couldn't compare
        if (isMouseLeftButtonDown == true && (actualCircleLocalScaleMagnitude < maxCirleLocalScaleMagnitude))
        {
            StopCoroutine(CircleDestroyDelay());
            circleObject.transform.localScale += new Vector3(0.3f, 0.3f, 0) * Time.deltaTime;
        }
        if (isMouseLeftButtonDown == false)
        {
            StartCoroutine(CircleDestroyDelay());
        }
    }

    private void MaxCircleScale()
    {
        maxCirleLocalScaleMagnitude = maxCircleLocalScale.magnitude;
    }

    private void PlayerMouseControl()
    {
        if (isMouseLeftButtonDown == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;

            //Convert mousePos to 2D world
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            //Clamp mouse position between min and max
            var deltaX = Mathf.Clamp(mousePos.x, xMin, xMax);
            var deltaY = Mathf.Clamp(mousePos.y, yMin, yMax);

            Vector3 normalizedPosition = new Vector3(deltaX, deltaY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, normalizedPosition, movementSpeed * Time.deltaTime);
        }
    }

    private void SetUpMoveBoundaries()
    {
        //Convert main camera to 2D world
        // x & y (0,1) always
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private IEnumerator CircleDestroyDelay()
    {
        yield return new WaitForSeconds(0.05f);
        circleObject.transform.localScale = new Vector3(0.25f, 0.25f, 0);
    }
}
