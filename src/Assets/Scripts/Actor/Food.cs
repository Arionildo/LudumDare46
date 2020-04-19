using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int amount;
    public string playerTag = "Player";
    private bool isAvailable = false;

    void Update()
    {
        if (isAvailable && Input.GetMouseButtonDown(0))
        {
            Debug.Log("+"+ amount + " de vida");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isAvailable = other.CompareTag(playerTag);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isAvailable = !other.CompareTag(playerTag);
    }
}
