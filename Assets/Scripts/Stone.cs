using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    SceneLoader loadGameOverScene;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = waypoints[waypointIndex].transform.position;

        loadGameOverScene = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = 5f * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                (transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            loadGameOverScene.LoadNextScene();
        }
    }
}
