using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Vector2 direction;
    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb2d;

    void Start()
    {
        Time.timeScale = 1;
        PlayerManager.instance.alive = true;
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (direction.magnitude > 0f)
        {
            animator.Play("Sprint");
        }
        else
        {
            animator.Play("Idle");
        }

        if (direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        if (direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }

        Vector2 force = direction * speed;
        rb2d.AddForce(force);
    }

    public void Die()
    {
        PlayerManager.instance.alive = false;
        Time.timeScale = 0;
    }
}