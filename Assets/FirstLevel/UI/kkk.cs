using UnityEngine;
using TMPro;

public class kkk : MonoBehaviour
{
    public PopUpPanel popUpPanel;
    public string message;

    private bool isPanelVisible;

    private void Start()
    {
        isPanelVisible = false;
        popUpPanel.HidePanel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isPanelVisible)
            {
                popUpPanel.ShowPanel(message);
                isPanelVisible = true;

                gameObject.SetActive(false); // Отключение текущего игрового объекта
            }
        }
    }
}
