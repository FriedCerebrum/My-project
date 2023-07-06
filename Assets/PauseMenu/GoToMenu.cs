using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    public void QuitToMenu()
    {
        // Загружаем сцену с главным меню по ее названию
        SceneManager.LoadScene("menu");
    }
}
