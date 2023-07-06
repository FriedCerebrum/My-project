using UnityEngine;

public class PauseMenuFix : MonoBehaviour
{
    private Canvas canvas;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false; // Отключаем отображение Canvas при запуске
    }

}
