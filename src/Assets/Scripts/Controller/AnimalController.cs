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
    public string playerTag = "Player";
    public int foodValue;
    public float moveSpotLimitPosition = 2.8f;

    private float waitTime;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isAttacking = false;
    private bool isDead = false;
    private bool isAvailable = false;

    void Start()
    {
        waitTime = startWaitTime;
        UpdateMoveSpot();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead && !isAttacking)
        {
            PatrolArea();
        }
        if (isDead && isAvailable && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("+" + foodValue + " de vida!");
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (!isDead && !isAttacking)
        {
            CheckFlipRenderer(moveSpot.position);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Bonfire"))
        {
            SetDeadState(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead)
        {
            Debug.Log("Pressione uma tecla para coletar o alimento!");
            isAvailable = other.CompareTag(playerTag);
            return;
        }

        if (other.CompareTag(playerTag))
        {
            Debug.Log("Fuja! Você está sendo atacado!");
            CheckFlipRenderer(other.transform.position);
            SetAttackState(true);
        }
        else
        {
            UpdateMoveSpot();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            SetAttackState(false);
            isAvailable = false;
        }
    }

    void PatrolArea()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) >= .2f)
        {
            return;
        }

        if (waitTime <= 0)
        {
            UpdateMoveSpot();
            waitTime = Random.Range(1, startWaitTime);
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    void UpdateMoveSpot()
    {
        float newX = transform.position.x + Random.Range(minHorizontal, maxHorizontal);
        float newY = transform.position.y + Random.Range(minVertical, maxVertical);
        moveSpot.position = new Vector2(newX, newY);

        if (Mathf.Abs(moveSpot.position.x) > moveSpotLimitPosition
            || Mathf.Abs(moveSpot.position.y) > moveSpotLimitPosition)
        {
            UpdateMoveSpot();
        }
    }

    void CheckFlipRenderer(Vector2 position)
    {
        if (transform.position.x < position.x)
        {
            FlipRenderer(true);
        }
        else if (transform.position.x > position.x)
        {
            FlipRenderer(false);
        }
        else
        {
            animator.enabled = false;
        }
    }

    void FlipRenderer(bool value)
    {
        spriteRenderer.flipX = value;
        animator.enabled = true;
    }

    void SetAttackState(bool value)
    {
        isAttacking = value;
        animator.SetBool("isAttack", isAttacking);
    }

    void SetDeadState(bool value)
    {
        isDead = value;
        animator.SetBool("isDead", isDead);
    }
}
