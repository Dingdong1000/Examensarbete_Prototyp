using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QuitGameTrigger : MonoBehaviour
{
    public GameObject exitText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowExitTextAndQuit());
        }
    }

    IEnumerator ShowExitTextAndQuit()
    {
        exitText.SetActive(true);
        
        yield return new WaitForSeconds(5f); // Vänta i 5 sekunder

        Debug.Log("Spelet avslutas!");
        
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); // Stoppar spelet i Unity Editor
        #else
        Application.Quit(); // Avslutar spelet i en byggd version
        #endif
    }
}
