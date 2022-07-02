using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private float health = 1f;
    public void Explode()
    {
        Debug.Log("Reached target");
        Destroy(gameObject);
    }

    public void TakeDamage(float f)
    {
        health -= f;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
