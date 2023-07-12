using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonologueManager : MonoBehaviour
{
    public GameObject monologuePanel;
    public TextMeshProUGUI monologueText;
    public Button contButton;

    private PlayerController playerController;

    void Start()
    {
        contButton.onClick.AddListener(CloseMonologueWindow);
        contButton.interactable = false;

        monologueText.text = "";

        playerController = FindObjectOfType<PlayerController>();
    }

    public void DisplayMonologue(string monologue)
    {
        monologueText.text = monologue;
        monologuePanel.SetActive(true);
        contButton.interactable = true;

        if (playerController != null)
        {
            playerController.canMove = false;
        }
    }

    public void CloseMonologueWindow()
    {
        monologueText.text = "";
        monologuePanel.SetActive(false);
        contButton.interactable = false;

        if (playerController != null)
        {
            playerController.canMove = true;
        }
    }
}
