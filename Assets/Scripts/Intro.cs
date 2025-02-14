
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public PlayerAudio playerAudio;
    public Image introImage;
    public TextMeshProUGUI initialText1;
    public TextMeshProUGUI initialText2;
    public TextMeshProUGUI initialText3;
    public TextMeshProUGUI introText1;
    public TextMeshProUGUI introText2;
    public TextMeshProUGUI introText3;
    public float displayTime = 2f;
    public float lastDisplayTime = 1f;
    public float typingSpeed = 0.1f;

    public GameObject player;
    private bool canProceed = false;
    private bool canInteract = false;

    void Start()
    {
        if (player != null)
        {
            player.SetActive(false);
        }
        
        introImage.gameObject.SetActive(true); // Se till att introImage visas
        StartCoroutine(InitialMessageRoutine());
    }

    IEnumerator InitialMessageRoutine()
    {
        introImage.CrossFadeAlpha(1f, 0f, false);
        
        
        
        initialText1.gameObject.SetActive(true);
        yield return StartCoroutine(TypeText(introText1, "for this experiment we want you to use headphones..."));
        yield return new WaitForSeconds(displayTime);

        initialText2.gameObject.SetActive(true);
        yield return StartCoroutine(TypeText(introText2, "...adjust the volume until this voice is at a comfortable level"));
        yield return new WaitForSeconds(displayTime);
        
        playerAudio.IntroVoice();
        initialText3.gameObject.SetActive(true);
        yield return StartCoroutine(TypeText(introText3, "press any key to continue"));
        
        yield return new WaitForSeconds(lastDisplayTime);

        canProceed = true;
    }

    void Update()
    {
        if (canProceed && Input.anyKeyDown)
        {
            canProceed = false;
            
            StartCoroutine(InitialFadeOut());
            StartCoroutine(IntroSequenceRoutine());
        }

        if (canInteract && Input.anyKeyDown)
        {
            StartCoroutine(FadeOut());
        }
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
    
    IEnumerator InitialFadeOut()
    {
        float fadeDuration = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alphaValue = 1f - (elapsedTime / fadeDuration);
            initialText1.CrossFadeAlpha(alphaValue, 0f, false);
            initialText2.CrossFadeAlpha(alphaValue, 0f, false);
            initialText3.CrossFadeAlpha(alphaValue, 0f, false);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        initialText1.gameObject.SetActive(false);
        initialText2.gameObject.SetActive(false);
        initialText3.gameObject.SetActive(false);
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





