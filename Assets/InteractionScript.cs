using UnityEngine;
using TMPro;

public class InteractionScript : MonoBehaviour
{
    public GameObject interactObject; // Объект, который будет активирован при взаимодействии
    public AudioClip interactSound; // Звук, который будет проигрываться при взаимодействии
    public TextMeshProUGUI interactText; // Объект TextMeshPro, в который будет выводиться текст

    private bool canInteract = false; // Флаг, указывающий, можно ли взаимодействовать
    private AudioSource audioSource; // Компонент AudioSource для проигрывания звука

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Получаем компонент AudioSource
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Если компонент отсутствует, добавляем его
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("key"))
        {
            canInteract = true;
            interactText.text = "Press E to unlock the door";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("key"))
        {
            canInteract = false;
            interactText.text = "";
        }
    }

    private void Interact()
    {
        audioSource.PlayOneShot(interactSound); // Проигрываем звук
        interactObject.SetActive(true); // Активируем объект

        // Задержка перед отключением объекта
        Invoke("DisableObject", 1f);
    }

    private void DisableObject()
    {
        gameObject.SetActive(false); // Деактивируем объект, к которому прикреплен скрипт
    }
}
