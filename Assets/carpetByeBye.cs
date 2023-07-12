using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionScript : MonoBehaviour
{
    public GameObject carpet;
    public TextMeshProUGUI interactionText;

    private bool isPlayerInTrigger = false;
    private MonoBehaviour TeleportTrigger;

    void Awake()
    {
        TeleportTrigger = GetComponent<MonoBehaviour>(); // Замените MonoBehaviour на тип вашего Teleport Trigger, если он не является MonoBehaviour.
        TeleportTrigger.enabled = false; // Предполагается, что Teleport Trigger отключен изначально.
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Предполагаем, что у игрока есть тег "Player"
        {
            isPlayerInTrigger = true;
            interactionText.text = "press E for fuck the carpet";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            interactionText.text = "";
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            carpet.SetActive(false);
            TeleportTrigger.enabled = true;
            this.enabled = false; // отключить этот скрипт
        }
    }
}
