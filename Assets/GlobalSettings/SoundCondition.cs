using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public Button soundToggleButton;

    private bool isSoundOn;

    void Start()
    {
        // Проверьте, включен ли звук
        isSoundOn = PlayerPrefs.GetInt("isSoundOn", 1) == 1; // По умолчанию звук включен

        AudioListener.volume = isSoundOn ? 1 : 0;
        UpdateButtonSprite();
        soundToggleButton.onClick.AddListener(ToggleSound);
    }

    void UpdateButtonSprite()
    {
        soundToggleButton.image.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        AudioListener.volume = isSoundOn ? 1 : 0;

        UpdateButtonSprite();

        // Сохраните состояние звука в PlayerPrefs
        PlayerPrefs.SetInt("isSoundOn", isSoundOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
