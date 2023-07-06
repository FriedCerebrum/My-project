using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportTrigger2 : MonoBehaviour
{
    public GameObject player; // Drag your player object into this slot in the inspector
    public Vector2 teleportLocation; // Set the coordinates where the player will be teleported
    public Text promptText; // Assign your Text object here to display the prompt

    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            playerInRange = true;
            promptText.text = "Нажмите 'T' для телепортации"; // Display prompt when player enters trigger
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            playerInRange = false;
            promptText.text = ""; // Remove prompt when player leaves trigger
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.T))
        {
            player.transform.position = teleportLocation; // Teleport player
            promptText.text = ""; // Remove prompt after teleporting
        }
    }
}
