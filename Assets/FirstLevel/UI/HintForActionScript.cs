using UnityEngine;
using TMPro;

public class ActionHintTrigger : MonoBehaviour
{
    public string hintMessage;  // Текст подсказки, который будет отображаться

    [SerializeField]
    private GameObject actionHint;  // Ссылка на объект ActionHint

    private void Awake()
    {
        // Находим дочерний объект ActionHint
        actionHint = transform.Find("ActionHint").gameObject;
        actionHint.SetActive(false);  // Изначально скрываем подсказку
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, если объект с rigidbody 2D входит в зону
        if (collision.CompareTag("Player"))
        {
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
            // Скрываем подсказку
            actionHint.SetActive(false);
        }
    }
}
