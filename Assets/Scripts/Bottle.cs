using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    SceneLoader loadGameOverScene;

    private void Start()
    {
        loadGameOverScene = FindObjectOfType<SceneLoader>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            loadGameOverScene.LoadNextScene();
        }
    }
}
