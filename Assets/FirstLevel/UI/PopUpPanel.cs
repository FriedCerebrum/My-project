using UnityEngine;
using TMPro;
using System.Collections;

public class PopUpPanel : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public AnimationCurve panelAnimationCurve;
    public float panelAnimationDuration = 1f;
    [SerializeField] private float panelHideDelay = 3f; // Задержка перед скрытием панели (в секундах)
    public AudioSource audioSource;
    public AudioClip panelOpenSound;
    public AudioClip panelCloseSound;

    private RectTransform panelRectTransform;
    private Vector3 panelStartPosition;
    private Vector3 panelEndPosition;
    private float panelAnimationStartTime;
    private bool isPanelOpen;

    private void Awake()
    {
        panelRectTransform = GetComponent<RectTransform>();
        panelStartPosition = panelRectTransform.localPosition;
        panelEndPosition = new Vector3(4f, 450f, 0f);
        isPanelOpen = false;
        HidePanel();
    }

    private void Update()
    {
        if (isPanelOpen)
        {
            float timeSinceAnimationStart = Time.time - panelAnimationStartTime;
            float t = Mathf.Clamp01(timeSinceAnimationStart / panelAnimationDuration);
            float curveT = panelAnimationCurve.Evaluate(t);

            panelRectTransform.localPosition = Vector3.Lerp(panelStartPosition, panelEndPosition, curveT);

            if (t >= 1f)
            {
                isPanelOpen = false;
                StartCoroutine(HidePanelWithDelay());
            }
        }
    }

    public void ShowPanel(string message)
    {
        textComponent.text = message;
        gameObject.SetActive(true);
        isPanelOpen = true;
        panelAnimationStartTime = Time.time;

        PlaySound(panelOpenSound);

        StartCoroutine(HidePanelWithDelay());
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
        PlaySound(panelCloseSound);
    }

    private IEnumerator HidePanelWithDelay()
    {
        yield return new WaitForSeconds(panelHideDelay);
        HidePanel();
    }

    private void PlaySound(AudioClip sound)
    {
        if (sound != null && audioSource != null)
        {
            audioSource.PlayOneShot(sound);
        }
    }

}
