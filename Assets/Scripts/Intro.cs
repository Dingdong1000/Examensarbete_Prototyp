using UnityEngine;
using TMPro;  // För att använda TextMeshPro-komponenter
using System.Collections;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public Image introImage;           // Referens till bilden
    public TextMeshProUGUI introText1; // Referens till första TextMeshPro-objektet
    public TextMeshProUGUI introText2;
    public TextMeshProUGUI introText3;// Referens till andra TextMeshPro-objektet
    public float displayTime = 2f;     // Hur länge varje text visas (i sekunder)
    public float lastDisplayTime = 1f;
    public float typingSpeed = 0.1f;   // Hur lång tid det tar för varje bokstav att visas (i sekunder)

    public GameObject player;
    private bool canInteract = false;

    void Start()
    {
        if (player != null)
        {
            player.SetActive(false);
        }
        // Starta introsekvensen när spelet startar
        StartCoroutine(IntroSequenceRoutine());
    }

    IEnumerator IntroSequenceRoutine()
    {
        // Visa bilden (t.ex. sätt alpha till 1 om den är genomskinlig)
        introImage.CrossFadeAlpha(1f, 0f, false); // Bilden blir synlig direkt
        introText1.gameObject.SetActive(true); // Gör den första texten synlig

        // Skriv ut första texten bokstav för bokstav
        yield return StartCoroutine(TypeText(introText1, "there will be three rooms to explore"));

        yield return new WaitForSeconds(displayTime); // Vänta 2 sekunder

        introText2.gameObject.SetActive(true); // Gör den andra texten synlig

        // Skriv ut andra texten bokstav för bokstav
        yield return StartCoroutine(TypeText(introText2, "when you're ready..."));

        yield return new WaitForSeconds(displayTime);
        
        yield return StartCoroutine(TypeText(introText3,"press any key to enter the prototype"));

        // Vänta ytterligare 2 sekunder innan spelaren kan interagera
        yield return new WaitForSeconds(lastDisplayTime);

        // Nu kan spelaren interagera genom att trycka på en knapp
        if (player != null)
        {
            player.SetActive(true);
        }
        
        canInteract = true;
    }

    // Coroutine som skriver ut text bokstav för bokstav
    IEnumerator TypeText(TextMeshProUGUI textMeshPro, string text)
    {
        textMeshPro.text = "";  // Nollställ texten
        foreach (char letter in text)
        {
            textMeshPro.text += letter;  // Lägg till en bokstav i taget
            yield return new WaitForSeconds(typingSpeed);  // Vänta mellan varje bokstav
        }
    }

    void Update()
    {
        // Kolla om spelaren har tryckt på en knapp och avsluta introsekvensen
        if (canInteract && Input.anyKeyDown)
        {
            // Här bleknar bilden och texterna ut
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        float fadeDuration = 1f;
        float elapsedTime = 0f;

        // Låt alla UI-element blekna ut
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

        // När allt har bleknat ut, gör alla objekt osynliga
        introImage.gameObject.SetActive(false);
        introText1.gameObject.SetActive(false);
        introText2.gameObject.SetActive(false);
        introText3.gameObject.SetActive(false);

        // Här kan du släppa spelaren att röra sig eller byta till spelets huvudsakliga scen
        // Om du behöver byta scen:
        // SceneManager.LoadScene("MainScene");
    }
}




