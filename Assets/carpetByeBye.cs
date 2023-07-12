using UnityEngine;

public class InteractWithCarpet : MonoBehaviour
{
    private GameObject carpet;
    private GameObject teleport;

    void Start()
    {
        // Получение ссылки на дочерние объекты "Carpet" и "Teleport"
        carpet = transform.Find("Carpet").gameObject;
        teleport = transform.Find("Teleport").gameObject;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Проверка, что игрок в зоне действия BoxCollider2D и нажал "E"
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // Отключение объекта "Carpet" и включение объекта "Teleport"
            carpet.SetActive(false);
            teleport.SetActive(true);

            // Отключение данного скрипта, чтобы не позволить повторно использовать функцию
            this.enabled = false;
        }
    }
}
