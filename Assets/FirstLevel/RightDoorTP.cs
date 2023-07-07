using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TeleportTrigger : MonoBehaviour
{
    public GameObject player; // Drag your player object into this slot in the inspector
    public Vector2 teleportLocation; // Set the coordinates where the player will be teleported
    public Text promptText; // Assign your Text object here to display the prompt
    public GameObject objectToFade; // Object to fade after teleporting
    public float fadeDuration = 1f; // Duration of the fading process

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
            StartCoroutine(FadeOutObject()); // Start the fading process
        }
    }

    private IEnumerator FadeOutObject()
    {
        // Make the object visible
        objectToFade.SetActive(true);

        SpriteRenderer spriteRenderer = objectToFade.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) yield break; 

        float fadeSpeed = 1 / fadeDuration;
        float alpha = 1f;
        
        while (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            spriteRenderer.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        // Completely disable the object
        objectToFade.SetActive(false);
    }
}
