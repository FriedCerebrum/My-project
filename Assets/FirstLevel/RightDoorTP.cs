using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TeleportTrigger : MonoBehaviour
{
    public GameObject player; 
    public Vector2 teleportLocation;
    public Text promptText; 
    public GameObject objectToFade; 
    public float fadeDuration = 1f;

    public GameObject cameraObject; // Object of your camera
    private CameraFollow cameraFollowScript; // Script "CameraFollow" attached to your camera

    public GameObject playerObject; // Object of your player
    private PlayerController playerControllerScript; // Script "PlayerController" attached to your player

    public float newCameraMinX; // New MinX value for the camera
    public float newCameraMaxX; // New MaxX value for the camera

    public float newPlayerMinX; // New MinX value for the player
    public float newPlayerMaxX; // New MaxX value for the player

    private bool playerInRange = false;

    private void Start()
    {
        cameraFollowScript = cameraObject.GetComponent<CameraFollow>();
        playerControllerScript = playerObject.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            playerInRange = true;
            promptText.text = "Нажмите 'T' для телепортации";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            playerInRange = false;
            promptText.text = "";
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.T))
        {
            player.transform.position = teleportLocation; 
            promptText.text = ""; 
            StartCoroutine(FadeOutObject());

            // Change the MinX and MaxX values of the camera
            cameraFollowScript.minX = newCameraMinX;
            cameraFollowScript.maxX = newCameraMaxX;

            // Change the MinX and MaxX values of the player
            playerControllerScript.minX = newPlayerMinX;
            playerControllerScript.maxX = newPlayerMaxX;
        }
    }

    private IEnumerator FadeOutObject()
    {
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

        objectToFade.SetActive(false);
    }
}
