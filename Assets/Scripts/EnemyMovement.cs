using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // enemies will move from 1 corner to another doing a zig zag

    private Rigidbody rb;
    private Vector3[] nodes = { new Vector3(150f,1.5f,0f), new Vector3(-150f,1.5f,0f), new Vector3(-150f,1.5f,60f)};
    private int state = 0;
    public float speed = 10f;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(MoveOnPath());
    }
    
    // make a path between object and the path;
    private IEnumerator MoveOnPath()
    {
        while (state < nodes.Length)
        {
            Vector3 distance = nodes[state] - transform.position;
            Vector3 step = distance.normalized;

            rb.velocity = step * speed;
            yield return new WaitForSeconds(distance.magnitude / (step.magnitude * speed));
            state++;
        }
        gameObject.GetComponent<EnemyState>().Explode();
    }
}
