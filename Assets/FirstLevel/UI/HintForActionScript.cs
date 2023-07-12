using UnityEngine;
using TMPro;

public class ActionHintTrigger : MonoBehaviour
{
    public string hintMessage;  // Текст подсказки, который будет отображаться

    public GameObject actionHint;  // Ссылка на объект ActionHint

    // Новые переменные для настройки предмета
    public Vector3 itemPositionOffset;
    public Quaternion itemRotation;
    public Vector3 itemScale;

    private GameObject player;  // ссылка на объект игрока

    private void Awake()
    {
        if (actionHint != null)
        {
            actionHint.SetActive(false);  // Изначально скрываем подсказку
        }
    }

    private void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.E))
        {
            // Привязываем предмет к объекту игрока, устанавливаем позицию, вращение и масштаб
            actionHint.transform.SetParent(player.transform);
            actionHint.transform.localPosition = itemPositionOffset;
            actionHint.transform.localRotation = itemRotation;
            actionHint.transform.localScale = itemScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, если объект с rigidbody 2D входит в зону
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;  // Сохраняем ссылку на объект игрока

            // Активируем подсказку
            actionHint.SetActive(true);

            // Обновляем текст подсказки
            TextMeshProUGUI textMesh = actionHint.GetComponentInChildren<TextMeshProUGUI>();
            textMesh.text = hintMessage;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Проверяем, если объект с rigidbody 2D выходит из зоны
        if (collision.CompareTag("Player"))
        {
            player = null;  // Очищаем ссылку на объект игрока

            // Скрываем подсказку
            actionHint.SetActive(false);
        }
    }
}
