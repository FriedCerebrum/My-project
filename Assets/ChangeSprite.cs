using UnityEngine;

public class DestroyRecord : MonoBehaviour
{
    public Sprite newSprite; // Новый спрайт, который вы хотите использовать.
    private SpriteRenderer spriteRenderer; // Ссылка на SpriteRenderer.
    private GameObject theMegaSound; // Ссылка на дочерний объект "TheMegaSound".

    private void Start()
    {
        // Получить компонент SpriteRenderer.
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Найти дочерний объект "TheMegaSound".
        theMegaSound = transform.Find("TheMegaSound").gameObject;
        // Отключить его в начале.
        theMegaSound.SetActive(false);
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

            // Включаем дочерний объект "TheMegaSound".
            theMegaSound.SetActive(true);

            // Отключаем скрипт.
            this.enabled = false;
        }
    }
}
