using UnityEngine;
using TMPro;

public class PickUpShovel : MonoBehaviour
{
    public GameObject shovel; // Объект ломика
    public TextMeshProUGUI instructionText; // Объект текста для отображения инструкции
    public Vector3 shovelPosition; // Позиция ломика относительно игрока
    public Quaternion shovelRotation; // Вращение ломика
    private bool canPickUp; // Проверка на то, может ли игрок поднять ломик

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Если игрок вошёл в триггер
        {
            canPickUp = true;
            instructionText.text = "Press 'E' to raise the crowbar."; // Изменение текста
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Если игрок вышел из триггера
        {
            canPickUp = false;
            instructionText.text = ""; // Очистка текста
        }
    }

    private void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E)) // Если игрок может поднять ломик и нажал "E"
        {
            AttachShovelToPlayer();
        }
    }

    private void AttachShovelToPlayer()
    {
        // Привязка ломика к игроку
        // Меняем родителя ломика на игрока и устанавливаем нужную позицию и вращение
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        shovel.transform.SetParent(playerTransform);
        shovel.transform.localPosition = shovelPosition; // Установите позицию
        shovel.transform.localRotation = shovelRotation; // Установите вращение
        instructionText.text = "";
    }
}
