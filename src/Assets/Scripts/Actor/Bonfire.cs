using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    public new string tag = "Player";
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float fireIntensity = 1f;
    private float lifeTime = 15f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetMouseButtonDown(0)
            && other.CompareTag(tag)
            && fireIntensity > 0)
        {
            fireIntensity -= .3f;
            spriteRenderer.color = new Color(1f, fireIntensity, fireIntensity, 1f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("saiu");
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
