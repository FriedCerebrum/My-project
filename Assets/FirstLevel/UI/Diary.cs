using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public GameObject[] pages; // Заполняется в редакторе Unity
    private List<int> unlockedPages = new List<int>();
    private int currentPage;
    private bool isDiaryOpen;

    private void Start() 
    {
    // Сначала делаем все страницы и сам дневник невидимыми
    foreach (GameObject page in pages) 
        {
            page.SetActive(false);
        }
    gameObject.SetActive(false);

    // "Разблокируем" первую страницу
    if (pages.Length > 0) 
        {
            UnlockPage(0);
        }
    isDiaryOpen = false; // Предполагается, что дневник закрыт при старте
    }


    public void UnlockPage(int pageNumber) 
    {
        if (pageNumber < 0 || pageNumber >= pages.Length) 
        {
            Debug.LogError("Invalid page number");
            return;
        }

        if (!unlockedPages.Contains(pageNumber)) 
        {
            unlockedPages.Add(pageNumber);
        }
    }

    private void OpenPage(int pageNumber) 
    {
        if (pageNumber < 0 || pageNumber >= pages.Length || !unlockedPages.Contains(pageNumber)) 
        {
            Debug.LogError("Cannot open page");
            return;
        }

        pages[currentPage].SetActive(false);
        pages[pageNumber].SetActive(true);
        currentPage = pageNumber;
    }

    public void NextPage() 
    {
        if (currentPage + 1 < pages.Length && unlockedPages.Contains(currentPage + 1)) 
        {
            OpenPage(currentPage + 1);
        }
    }

    public void PrevPage() 
    {
        if (currentPage - 1 >= 0 && unlockedPages.Contains(currentPage - 1)) 
        {
            OpenPage(currentPage - 1);
        }
    }

    public void OpenDiary() 
    {
        gameObject.SetActive(true);

        // Делаем все страницы невидимыми
        foreach (GameObject page in pages) 
        {
            page.SetActive(false);
        }

        // Открываем последнюю разблокированную страницу
        if (unlockedPages.Count > 0) 
        {
            OpenPage(unlockedPages[unlockedPages.Count - 1]);
        }
        isDiaryOpen = true;
    }

    public void CloseDiary() 
    {
        gameObject.SetActive(false);
        isDiaryOpen = false;
    }

    public void ToggleDiary()
    {
        if (isDiaryOpen)
        {
            CloseDiary();
        }
        else
        {
            OpenDiary();
        }
    }
}
