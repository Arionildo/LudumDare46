using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public float speed = 10;
    public float startWaitTime = 3;
    public float minHorizontal = -3;
    public float minVertical = -3;
    public float maxHorizontal = 3;
    public float maxVertical = 3;
    public Transform moveSpot;

    private float waitTime;

    void Start()
    {
        waitTime = startWaitTime;
        // moveSpot = transform;
        moveSpot.position = new Vector2(Random.Range(minHorizontal, maxHorizontal), Random.Range(minVertical, maxVertical));
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < .2f)
        {
            if (waitTime <= 0) {
                moveSpot.position = new Vector2(Random.Range(minHorizontal, maxHorizontal), Random.Range(minVertical, maxVertical));
                waitTime = startWaitTime;
            } else {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
