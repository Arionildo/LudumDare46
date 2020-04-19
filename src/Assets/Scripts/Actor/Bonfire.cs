using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    public new string playerTag = "Player";
    private SpriteRenderer spriteRenderer;
    private float fireIntensity = 1f;
    private bool isAvailable = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isAvailable
            && fireIntensity > 0
            && Input.GetMouseButtonDown(0))
        {
            fireIntensity -= .3f;
            spriteRenderer.color = new Color(1f, fireIntensity, fireIntensity, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isAvailable = other.CompareTag(playerTag) && fireIntensity > 0;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isAvailable = !other.CompareTag(playerTag);
        fireIntensity = 1;
        spriteRenderer.color = new Color(1f, .3f, .3f, 1f);
    }
}
