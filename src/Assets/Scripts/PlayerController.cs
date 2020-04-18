using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private float moveHorizontal;
    private float moveVertical;

    void Start()
    {
        Time.timeScale = 1;
        PlayerManager.instance.alive = true;
    }

    void Update()
    {

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(moveHorizontal, moveVertical);
        Vector2 translate = direction * Time.deltaTime * (speed * PlayerManager.gameSpeed);


        transform.Translate(translate);
    }

    public void Die()
    {
        PlayerManager.instance.alive = false;
        Time.timeScale = 0;
    }

    public void Stop()
    {
        moveHorizontal = 0;
    }
}