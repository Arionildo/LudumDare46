using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    public new string playerTag = "Player";
    public float maxLifeTime = 15f;
    public float largeBonfireTriggerTime = 10f;
    public float largeBonfireTriggerTime = 5f;
    private Animator animator;
    private bool isAvailable = false;
    private float currentLifeTime;

    void Start()
    {
        currentLifeTime = maxLifeTime;
        animator = GetComponent<Animator>();
    }
    
    void FixedUpdate() {
        updateLifeTime();
        setBonfire(currentLifeTime);

        if (isAvailable
            && Input.GetMouseButtonDown(0)
            && currentLifeTime < maxLifeTime){
            feedFire();
            isAvailable = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isAvailable = other.CompareTag(playerTag);
        Debug.Log("Pressione uma tecla para jogar o graveto na fogueira!");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isAvailable = !other.CompareTag(playerTag);
    }

    void updateLifeTime() {
        currentLifeTime -= Time.deltaTime;
        if (currentLifeTime < 0) {
            currentLifeTime = 0;
        }
    }

    void feedFire(){
        currentLifeTime += 5;
        if (currentLifeTime > maxLifeTime) {
            currentLifeTime = maxLifeTime;
        }
        Debug.Log("A fogueira durará mais algum tempo!");
    }

    void setBonfire(float lifeTime) {
        if(lifeTime > largeBonfireTriggerTime){
            setLargeBonfire();
        } else if(lifeTime > mediumBonfireTriggerTime){
            setMediumBonfire();
        } else {
            setSmallBonfire();
        }
    }

    void setLargeBonfire(){
        animator.SetBool("idle", true);
        animator.SetBool("medio", false);
        animator.SetBool("small", false);
    }

    void setMediumBonfire(){
        animator.SetBool("idle", false);
        animator.SetBool("medio", true);
        animator.SetBool("small", false);
    }

    void setSmallBonfire(){
        animator.SetBool("idle", false);
        animator.SetBool("medio", false);
        animator.SetBool("small", true);
    }

}
