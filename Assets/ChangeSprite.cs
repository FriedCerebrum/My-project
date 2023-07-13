using UnityEngine;

public class DestroyRecord : MonoBehaviour
{
    public Sprite newSprite; // Новый спрайт, который вы хотите использовать.
    private SpriteRenderer spriteRenderer; // Ссылка на SpriteRenderer.
    
    private void Start()
    {
        // Получить компонент SpriteRenderer.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверить, является ли столкнувшийся объект "Record".
        if (collision.gameObject.name == "Record")
        {
            // Уничтожаем объект "Record".
            Destroy(collision.gameObject);

            // Меняем спрайт.
            spriteRenderer.sprite = newSprite;

            // Отключаем скрипт.
            this.enabled = false;
        }
    }
}
