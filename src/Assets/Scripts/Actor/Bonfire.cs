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
        fireIntensity = 1;
        spriteRenderer.color = new Color(1f, .3f, .3f, 1f);
    }

    void FixedUpdate() {
        lifeTime -= Time.deltaTime;
        Debug.Log(lifeTime);
        if(lifeTime < 10){
            animator.SetBool("medio", true);
        }
    }

    void setLargeBonfire(){

    }

    void setMediumBonfire(){

    }

    void setSmallBonfire(){

    }

}
