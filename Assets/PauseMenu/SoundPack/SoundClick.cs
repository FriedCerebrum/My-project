using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickSound : MonoBehaviour
{
    public AudioClip[] clickSounds; // Загрузите ваши звуки нажатия кнопки в этот массив через редактор Unity.
    private Button button;
    private AudioSource audioSource;

    void Start()
    {
        button = GetComponent<Button>();
        audioSource = gameObject.AddComponent<AudioSource>();
        button.onClick.AddListener(PlayRandomClickSound);
    }

    void PlayRandomClickSound()
    {
        if (clickSounds.Length > 0)
        {
            int index = Random.Range(0, clickSounds.Length);
            audioSource.PlayOneShot(clickSounds[index]);
        }
    }
}
