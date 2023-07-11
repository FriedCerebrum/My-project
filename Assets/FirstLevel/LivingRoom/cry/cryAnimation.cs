using UnityEngine;

public class CryingAnimation : MonoBehaviour
{
    public Sprite[] cryingSprites; // Массив спрайтов плача
    public float frameRate = 0.2f; // Частота смены спрайтов

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex;
    private float timer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer = 0f;
            currentSpriteIndex = (currentSpriteIndex + 1) % cryingSprites.Length;
            spriteRenderer.sprite = cryingSprites[currentSpriteIndex];
        }
    }
}
