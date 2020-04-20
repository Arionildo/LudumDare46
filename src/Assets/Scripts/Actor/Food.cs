using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int foodValue;
    public string playerTag = "Player";
    public Sprite spriteWithoutFood;
    public float cooldown = 15;
    private Sprite spriteWithFood;
    private bool isAvailable = false;
    public float currentCooldown;

    void Start()
    {
        spriteWithFood = GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {
        if (isAvailable
            && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("+" + foodValue + " de vida!");
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
        if (currentCooldown <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = spriteWithFood;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isAvailable = other.CompareTag(playerTag);
        if (isAvailable)
        {
            Debug.Log("Pressione uma tecla para coletar o alimento!");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            isAvailable = false;
        }
    }
}
