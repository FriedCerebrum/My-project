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

    public GameObject cameraObject; 
    private CameraFollow cameraFollowScript;

    public GameObject playerObject;
    private PlayerController playerControllerScript;

    public float newCameraMinX;
    public float newCameraMaxX;

    public float newPlayerMinX;
    public float newPlayerMaxX;

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

            cameraFollowScript.minX = newCameraMinX;
            cameraFollowScript.maxX = newCameraMaxX;

            playerControllerScript.minX = newPlayerMinX;
            playerControllerScript.maxX = newPlayerMaxX;

            Vector3 destinationDirection = teleportLocation - (Vector2)player.transform.position;
            if (destinationDirection.x > 0 && !playerControllerScript.IsFacingRight())
            {
                playerControllerScript.ForceFlip();
            }
            else if (destinationDirection.x < 0 && playerControllerScript.IsFacingRight())
            {
                playerControllerScript.ForceFlip();
            }
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
