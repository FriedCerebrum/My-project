using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[Serializable]
public class MonologueTrigger
{
    public string monologueText;
}

public class MainCharacter : MonoBehaviour
{
    public static MainCharacter currentMonologueCharacter;

    public GameObject monologuePanel;
    public TextMeshProUGUI monologueText;
    public GameObject monologueHint;
    public List<MonologueTrigger> monologueTriggers;
    private string currentMonologue;
    public Button contButton; // changed from GameObject to Button
    public float wordSpeed;
    private Coroutine typingCoroutine;
    private Coroutine inputCoroutine;
    private bool inTriggerZone = false;
    private Queue<MonologueTrigger> monologueQueue;
    private PlayerController playerController;

    void Start()
    {
        contButton.onClick.AddListener(NextMonologue);
        contButton.interactable = false;  // button is initially disabled

        monologueText.text = "";
        monologueHint.SetActive(false);
        monologueQueue = new Queue<MonologueTrigger>(monologueTriggers);
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (this == currentMonologueCharacter)
        {
            contButton.interactable = true;
        }
        else
        {
            contButton.interactable = false;
        }

        if (inTriggerZone && !monologuePanel.activeInHierarchy && monologueQueue.Count > 0)
        {
            currentMonologue = monologueQueue.Dequeue().monologueText;
            monologuePanel.SetActive(true);
            monologueHint.SetActive(false);
            typingCoroutine = StartCoroutine(Typing());
            inputCoroutine = StartCoroutine(CheckForInput());
            currentMonologueCharacter = this; // set current active monologue character
        }

        if (monologueText.text == currentMonologue)
        {
            contButton.interactable = true;
        }
    }

    public void PauseMonologue()
    {
        monologueText.text = "";
        monologuePanel.SetActive(false);
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        if (inputCoroutine != null)
        {
            StopCoroutine(inputCoroutine);
            inputCoroutine = null;
        }
    }

    public void ResetText()
    {
        monologueText.text = "";
        monologuePanel.SetActive(false);
        contButton.interactable = false;
        monologueHint.SetActive(false);
        monologueQueue = new Queue<MonologueTrigger>(monologueTriggers);
    }

    IEnumerator Typing()
    {
        StringBuilder sb = new StringBuilder();
        foreach (char letter in currentMonologue.ToCharArray())
        {
            sb.Append(letter);
            monologueText.text = sb.ToString();
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    IEnumerator CheckForInput()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Q) && monologuePanel.activeInHierarchy)
            {
                PauseMonologue();
            }

            yield return null;
        }
    }

    public void CloseMonologueWindow()
    {
        monologueText.text = "";
        monologuePanel.SetActive(false);
        contButton.interactable = false;
        monologueHint.SetActive(false);

        if (playerController != null)
        {
            playerController.canMove = true; // Разрешить игроку движение при закрытии диалогового окна
        }

        // Отключение объекта, к которому привязан скрипт
        gameObject.SetActive(false);
    }

    public void NextMonologue()
    {
        if (this == currentMonologueCharacter) // check if this instance is the current active monologue character
        {
            contButton.interactable = false;

            if (monologueQueue.Count > 0)
            {
                currentMonologue = monologueQueue.Dequeue().monologueText;
                monologueText.text = "";
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine);
                }
                typingCoroutine = StartCoroutine(Typing());
            }
            else
            {
                CloseMonologueWindow();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = true;
            monologueHint.SetActive(true);
            if (playerController != null)
            {
                playerController.canMove = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = false;
            monologueHint.SetActive(false);
            if (playerController != null)
            {
                playerController.canMove = true;
            }
        }
    }
}
