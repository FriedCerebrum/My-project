using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioClip audioClip;  // Аудиофайл, который будет воспроизводиться

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

            // Воспроизводим аудиофайл
            audioSource.Play();

            // Уничтожаем пустой объект через время длительности аудиофайла
            Destroy(audioObject, audioClip.length);
        }
    }
}
