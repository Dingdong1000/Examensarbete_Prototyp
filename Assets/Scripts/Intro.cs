
using UnityEngine;
using TMPro;
using System.Collections;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.UI;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class Intro : MonoBehaviour
{
    public Image introImage;
    public CanvasGroup initialText0;
    public TextMeshProUGUI initialText1;
    public TextMeshProUGUI initialText2;
    public TextMeshProUGUI initialText3;
    public TextMeshProUGUI introText1;
    public TextMeshProUGUI introText2;
    public TextMeshProUGUI introText3;
    public GameObject canvasText1;
    public float displayTime = 2f;
    public float lastDisplayTime = 1f;
    public float typingSpeed = 0.01f;

    private EventInstance introVoice;
    public GameObject player;
    private bool canProceed = false;
    private bool canInteract = false;
    public float fadeDuration = 2f;

    void Start()
    {
        if (player != null)
        {
            player.SetActive(false);
        }

        initialText0.alpha = 0;
        StartCoroutine(FadeIn());
        introImage.gameObject.SetActive(true); // Se till att introImage visas
        StartCoroutine(InitialMessageRoutine());
    }

    IEnumerator InitialMessageRoutine()
    {
        yield return new WaitForSeconds(2f); 
        introImage.CrossFadeAlpha(1f, 0f, false);
        yield return new WaitForSeconds(11f);

        initialText1.gameObject.SetActive(true);
        yield return StartCoroutine(TypeText(initialText1, "for this experiment we need you to use headphones..."));
        yield return new WaitForSeconds(displayTime);

        initialText2.gameObject.SetActive(true);
        yield return StartCoroutine(TypeText(initialText2, "...adjust the volume until this voice is at a comfortable level"));
        yield return new WaitForSeconds(displayTime);

        introVoice = RuntimeManager.CreateInstance("event:/ExJobb/Intro-Voice/Intro-Voice");
        introVoice.start();
        
        initialText3.gameObject.SetActive(true);
        yield return StartCoroutine(TypeText(initialText3, "press any key to continue"));
        
        yield return new WaitForSeconds(lastDisplayTime);

        canProceed = true;
        
    }

    void Update()
    {
        if (canProceed && Input.anyKeyDown)
        {
            canProceed = false;
            canvasText1.SetActive(false);
            StartCoroutine(IntroSequenceRoutine());
            StopEvent();
        }

        if (canInteract && Input.anyKeyDown)
        {
            StartCoroutine(FadeOut());
        }
    }

    public void StopEvent()
    {
        introVoice.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        introVoice.release();
    }

    IEnumerator IntroSequenceRoutine()
    {
        introText1.gameObject.SetActive(true);
        yield return StartCoroutine(TypeText(introText1, "there will be three rooms to explore"));
        yield return new WaitForSeconds(displayTime);

        introText2.gameObject.SetActive(true);
        yield return StartCoroutine(TypeText(introText2, "when you're ready..."));
        yield return new WaitForSeconds(displayTime);
        
        introText3.gameObject.SetActive(true);
        yield return StartCoroutine(TypeText(introText3, "press any key to enter the prototype"));
        
        yield return new WaitForSeconds(lastDisplayTime);
        
        if (player != null)
        {
            player.SetActive(true);
        }
        
        canInteract = true;
    }

    IEnumerator TypeText(TextMeshProUGUI textMeshPro, string text)
    {
        textMeshPro.text = "";
        foreach (char letter in text)
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(2f);
        
        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            initialText0.alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            yield return null;
        }

        // Display fully visible for a duration
        yield return new WaitForSeconds(5f);

        // Fade Out
        timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            initialText0.alpha = Mathf.Lerp(1, 0, timer / fadeDuration);
            yield return null;
        }
    }


    IEnumerator FadeOut()
    {
        float fadeDuration = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alphaValue = 1f - (elapsedTime / fadeDuration);
            introImage.CrossFadeAlpha(alphaValue, 0f, false);
            introText1.CrossFadeAlpha(alphaValue, 0f, false);
            introText2.CrossFadeAlpha(alphaValue, 0f, false);
            introText3.CrossFadeAlpha(alphaValue, 0f, false);
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        introImage.gameObject.SetActive(false);
        introText1.gameObject.SetActive(false);
        introText2.gameObject.SetActive(false);
        introText3.gameObject.SetActive(false);
    }
}





