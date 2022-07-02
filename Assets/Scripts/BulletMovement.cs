using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private GameObject target;
    private Rigidbody rb;
    private float speed = 100f;
    
    public void Initialize(GameObject obj)
    {
        target = obj;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        Vector3 distance = target.transform.position - transform.position;
        Vector3 step = distance.normalized;

        rb.velocity = step * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyState>().TakeDamage(1f);
            Destroy(gameObject);
        }
    }
}
