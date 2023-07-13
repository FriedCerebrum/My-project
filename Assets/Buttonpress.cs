using UnityEngine;

public class SoundButton : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;

    private void Awake()
    {
        // Получаем компонент AudioSource при инициализации скрипта
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // Устанавливаем звуковой клип для AudioSource из инспектора Unity
        audioSource.clip = soundClip;
    }

    public void PlaySound()
    {
        // Проверяем, что звуковой клип существует
        if (soundClip != null)
        {
            // Воспроизводим звуковой клип
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Звуковой клип не установлен!");
        }
    }
}
