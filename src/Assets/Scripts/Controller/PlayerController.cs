using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Vector2 direction;
    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb2d;

    private AudioSource audioSource;

    void Start()
    {
        Time.timeScale = 1;
        PlayerManager.instance.alive = true;
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (direction.magnitude > 0f)
        {
            animator.Play("Sprint");
            audioSource.enabled = true;
        }
        else
        {
            animator.Play("Idle");
            audioSource.enabled = false;
        }

        if (direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        else if (direction.x > 0)
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