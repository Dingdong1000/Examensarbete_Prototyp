using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class LightSequence : MonoBehaviour
{
    public GameObject[] lights; // Array av lampor i ordning
    public GameObject doorToOpen;
    public LightSequence nextRoom;
    public float requiredTime = 5f; // Tid spelaren måste stå i ljuset

    public TextMeshProUGUI timerText;

    private int currentIndex = 0;
    private bool isPlayerInLight = false;
    private float timer = 0f;

    private LightSequence activeController;

    void Start()
    {
        // Inaktivera om det redan finns en aktiv controller
        if (activeController != null && activeController != this)
        {
            gameObject.SetActive(false);
            return;
        }

        activeController = this; // Sätt denna som aktiv
        // Se till att bara första lampan och dess trigger är aktiva
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(i == 0);
        }
    }

    void Update()
    {
        if (isPlayerInLight)
        {
            timer += Time.deltaTime;
            float timeLeft = Math.Clamp(requiredTime - timer, 0, requiredTime); 
            timerText.text = timeLeft.ToString("0.0");
            if (timer >= requiredTime)
            {
                NextLight();
            }
        }
        else
        {
            timer = 0f; // Återställ timer om spelaren lämnar ljuset
            timerText.text = " ";
        }
    }

    void NextLight()
    {
        lights[currentIndex].SetActive(false);  // Släck nuvarande lampa

        currentIndex++;

        if (currentIndex < lights.Length)
        {
            lights[currentIndex].SetActive(true); // Tänd nästa lampa
        }
        else
        {
            // Alla lampor har varit aktiva, öppna dörren
            if (doorToOpen)
                doorToOpen.SetActive(false); // Öppna dörren
            
            ActivateNextRoom();
        }

        isPlayerInLight = false;
        timer = 0f;
    }

    public void PlayerEnteredLightZone()
    {
        isPlayerInLight = true;
    }

    public void PlayerLeftLightZone()
    {
        isPlayerInLight = false;
        timer = 0f;
    }

    void ActivateNextRoom()
    {
        if (nextRoom != null)
        {
            nextRoom.gameObject.SetActive(true); // Aktivera nästa rum
            activeController = nextRoom; // Sätt nästa rum som aktiv controller
        }

        gameObject.SetActive(false); // Inaktivera nuvarande rum
    }
}


