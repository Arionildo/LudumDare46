using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int amount;
    public string playerTag = "Player";
    public Sprite spriteWithoutFood;
    public float cooldown = 15;
    private Sprite spriteWithFood;
    private bool isAvailable = false;
    private float currentCooldown;

    void Start()
    {
        spriteWithFood = GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {
        if (isAvailable
            && Input.GetMouseButtonDown(0))
        {
            Debug.Log("+" + amount + " de vida!");
            isAvailable = false;
            GetComponent<SpriteRenderer>().sprite = spriteWithoutFood;
            currentCooldown = cooldown;
        }
    }

    void FixedUpdate()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        if (currentCooldown <= 0) {
            isAvailable = true;
            GetComponent<SpriteRenderer>().sprite = spriteWithFood;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Pressione uma tecla para coletar o alimento!");
        isAvailable = other.CompareTag(playerTag) && currentCooldown <= 0;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isAvailable = !other.CompareTag(playerTag);
    }
}
