using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioClip audioClip;  // Аудиофайл, который будет воспроизводиться
    public float volume = 1f;  // Громкость звука (от 0 до 1)

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, если объект, с которым столкнулся триггер, является игровым объектом с тегом "Player"
        if (other.CompareTag("Player"))
        {
            // Создаем пустой игровой объект для воспроизведения звука
            GameObject audioObject = new GameObject("AudioObject");
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();

            // Устанавливаем аудиофайл для AudioSource
            audioSource.clip = audioClip;

            // Устанавливаем громкость звука
            audioSource.volume = volume;

            // Воспроизводим аудиофайл
            audioSource.Play();

            // Уничтожаем пустой объект через время длительности аудиофайла
            Destroy(audioObject, audioClip.length);
        }
    }
}
