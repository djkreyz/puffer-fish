using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShredder : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D enemy)
    {
        Destroy(enemy.gameObject);
    }
}
