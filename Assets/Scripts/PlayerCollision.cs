using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController player;
    private void OnTriggerEnter2D(Collider2D collision) {
        player.OnTriggerEnter2D(collision);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        player.OnTriggerExit2D(collision);
    }
}
