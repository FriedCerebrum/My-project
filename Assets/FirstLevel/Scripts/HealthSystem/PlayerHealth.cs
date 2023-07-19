using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное количество здоровья
    private int currentHealth;  // Текущее количество здоровья

    public Image[] hearts; // Массив спрайтов сердечек
    public Sprite fullHeart; // Спрайт полного сердца
    public Sprite emptyHeart; // Спрайт пустого сердца

    void Start()
    {
        // Инициализация здоровья при старте игры
        currentHealth = maxHealth;

        // Инициализация сердечек
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        // Уменьшение здоровья при получении урона
        currentHealth -= damage;

        // Обновление UI
        UpdateHearts();

        // Проверка, не умер ли игрок
        if (currentHealth <= 0)
        {
            // TODO: Вставьте здесь код, который должен выполниться при смерти игрока
        }
    }

    public void Heal(int amount)
    {
        // Увеличение здоровья при лечении
        currentHealth += amount;

        // Обновление UI
        UpdateHearts();

        // Проверка, не превышает ли текущее здоровье максимальное
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void UpdateHearts()
    {
        // Вычисление количества полных сердец
        int fullHearts = currentHealth / 20;

        // Заполнение полных сердец
        for (int i = 0; i < fullHearts; i++)
        {
            hearts[i].sprite = fullHeart;
        }

        // Очистка остальных сердец
        for (int i = fullHearts; i < hearts.Length; i++)
        {
            hearts[i].sprite = emptyHeart;
        }
    }
}
