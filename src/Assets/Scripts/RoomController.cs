using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public string playerTag = "Player";

    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log("entrou");
        if (other.CompareTag(playerTag)) {
            CameraController.instance.SetPosition(new Vector2(transform.position.x, transform.position.y));
        }
        Debug.Log("saiu");
    }
}
