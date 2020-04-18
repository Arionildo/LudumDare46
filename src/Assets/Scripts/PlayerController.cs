using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float minPositionX;
    public float maxPositionX;
    private float moveHorizontal;

    void Start() {
        Time.timeScale = 1;
        PlayerManager.instance.alive = true;
    }

    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            moveHorizontal = Input.GetAxis("Horizontal");
        }
        Vector2 translate = Vector2.right * moveHorizontal * Time.deltaTime * (speed * PlayerManager.gameSpeed);

        if (CanMove(translate))
        {
            transform.Translate(translate);
        }
    }

    private bool CanMove(Vector2 translate)
    {
        if(translate.x > 0){
            return transform.position.x <= maxPositionX;
        } else if(translate.x < 0)
        {
            return transform.position.x >= minPositionX;
        } else
        {
            return false;
        }
    }

    public void Die() {
        PlayerManager.instance.alive = false;
        Time.timeScale = 0;
    }

    public void GoLeft()
    {
        moveHorizontal = -1;
    }

    public void GoRight()
    {
        moveHorizontal = 1;
    }

    public void Stop()
    {
        moveHorizontal = 0;
    }
}