using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public AudioClip soundEffect;  // Звуковой эффект, указываем через инспектор

    private bool isPlayerInTrigger = false;
    private GameObject playerCrowbar;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCrowbar = collision.transform.Find("crowbar")?.gameObject;
            isPlayerInTrigger = playerCrowbar != null;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            playerCrowbar = null;
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (soundEffect != null)
            {
                AudioSource.PlayClipAtPoint(soundEffect, transform.position);
            }

            if (playerCrowbar != null)
            {
                playerCrowbar.SetActive(false);
            }

            gameObject.SetActive(false);
        }
    }
}
