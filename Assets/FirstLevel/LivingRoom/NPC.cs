using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[Serializable]
public class Dialogue
{
    public List<string> lines = new List<string>();
}

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueHint;
    public List<Dialogue> dialogues;
    private List<string> currentDialogue;
    private int index = 0;
    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;
    private Coroutine typingCoroutine;
    private GameObject player; // Объект игрока
    public float dialogueRange = 5.0f; // Расстояние для взаимодействия с диалогом

    void Start()
    {
        dialogueText.text = "";
        dialogueHint.SetActive(false);
        currentDialogue = dialogues[0].lines;
        player = GameObject.FindWithTag("Player"); // Получение объекта игрока
    }

    void Update()
    {
        // Проверка расстояния между NPC и игроком
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if (distance > dialogueRange)
        {
            playerIsClose = false;
            StopDialogue();
        }
        else
        {
            playerIsClose = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                dialogueHint.SetActive(false);
                typingCoroutine = StartCoroutine(Typing());
            }
            else if (dialogueText.text == currentDialogue[index])
            {
                NextLine();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
        {
            StopDialogue();
        }

        if(dialogueText.text == currentDialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void StopDialogue()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
    }

    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        contButton.SetActive(false);
        dialogueHint.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in currentDialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if (index < currentDialogue.Count - 1)
        {
            index++;
            dialogueText.text = "";
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            typingCoroutine = StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueHint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueHint.SetActive(false);
        }
    }
    public void SetDialogue(int dialogueIndex)
{
    if (dialogueIndex >= 0 && dialogueIndex < dialogues.Count)
    {
        currentDialogue = dialogues[dialogueIndex].lines;
        index = 0;
    }
    else
    {
        Debug.LogError("Invalid dialogue index");
    }
}

}
