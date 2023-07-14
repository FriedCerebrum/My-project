using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject theMegaSound;
    public GameObject ghostGirl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && theMegaSound.activeSelf)
        {
            ghostGirl.SetActive(false);
        }
    }
}
