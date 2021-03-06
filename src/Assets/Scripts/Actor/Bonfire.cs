using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonfire : MonoBehaviour
{
    public string playerTag = "Player";
    public float maxLifeTime = 15f;
    public float largeBonfireTriggerTime = 15f;
    public float mediumBonfireTriggerTime = 10f;
    public float smallBonfireTriggerTime = 5f;
    private Animator animator;

    private bool isAvailable = false;

    private float currentLifeTime;

    public Slider progressBonfire;
    public float targetProgressFire;

    private MessageController msgController;


    void Start()
    {
        currentLifeTime = maxLifeTime;
        animator = GetComponent<Animator>();
        msgController = GetComponent<MessageController>();
    }

    void FixedUpdate()
    {
        updateLifeTime();
        setBonfire(currentLifeTime);

        if (isAvailable
            && Input.GetKeyDown(KeyCode.Space)
            && currentLifeTime < maxLifeTime)
        {
            feedFire();
            isAvailable = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isAvailable = other.CompareTag(playerTag);
        msgController.ShowMessage("Press Space to throw a stick on the bonfire");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            isAvailable = false;
        }
    }

    void updateLifeTime()
    {
        currentLifeTime -= Time.deltaTime;
        if (currentLifeTime < 0)
        {
            currentLifeTime = 0;
        }
    }

    void feedFire()
    {
        currentLifeTime += 20;
        if (currentLifeTime > maxLifeTime)
        {
            currentLifeTime = maxLifeTime;
        }
        msgController.ShowMessage("Hope the bonfire will last longer!");
    }

    void setBonfire(float lifeTime)
    {
        progressBonfire.value = lifeTime;
        if (lifeTime > largeBonfireTriggerTime)
        {
            setLargeBonfire();
        }
        else if (lifeTime > mediumBonfireTriggerTime)
        {
            setMediumBonfire();
        }
        else
        {
            setSmallBonfire();
        }
    }

    void setLargeBonfire()
    {
        animator.SetBool("idle", true);
        animator.SetBool("medio", false);
        animator.SetBool("small", false);
    }

    void setMediumBonfire()
    {
        animator.SetBool("idle", false);
        animator.SetBool("medio", true);
        animator.SetBool("small", false);
    }

    void setSmallBonfire()
    {
        animator.SetBool("idle", false);
        animator.SetBool("medio", false);
        animator.SetBool("small", true);
    }

}
