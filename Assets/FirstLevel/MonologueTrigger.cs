using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonologueTrigger : MonoBehaviour
{
    public MonologueManager monologueManager;
    public string monologueText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            monologueManager.DisplayMonologue(monologueText);

            // Отключение объекта, к которому прикреплен скрипт
            gameObject.SetActive(false);
        }
    }
}
