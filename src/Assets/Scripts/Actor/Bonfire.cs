using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    public new string playerTag = "Player";
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float fireIntensity = 1f;
    private bool isAvailable = false;
    private float lifeTime = 15f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
        feedFire();
    }
    
    void FixedUpdate() {
        lifeTime -= Time.deltaTime;
        if(lifeTime > 10){
            animator.SetBool("idle", true);
            animator.SetBool("medio", false);
            animator.SetBool("small", false);
        } else if(lifeTime > 5){
            animator.SetBool("medio", true);
            animator.SetBool("idle", false);
            animator.SetBool("small", false);
        } else {
            animator.SetBool("idle", false);
            animator.SetBool("medio", false);
            animator.SetBool("small", true);
        }
        if(lifeTime < 0){
            lifeTime = 15;
        }
    }

    void feedFire(){
        lifeTime += 5;
    }

    void setLargeBonfire(){

    }

    void setMediumBonfire(){

    }

    void setSmallBonfire(){

    }

}
