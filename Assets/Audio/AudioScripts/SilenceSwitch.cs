using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SilenceSwitch : MonoBehaviour
{
    [SerializeField]
    [Range(0,3)]
    int switchInput;

    public Image totalSilence;
    private bool isVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        { 
            switchInput = 0;
            HideImage();
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Sound Switch", switchInput);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            switchInput = 1;
            HideImage();
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Sound Switch", switchInput); 
        }
        
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        { 
            switchInput = 2;
            HideImage();
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Sound Switch", switchInput);
        }
        
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            switchInput = 3;
            ShowImage();
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Sound Switch", switchInput); 
        }
    }

    void ShowImage()
    {
        totalSilence.gameObject.SetActive(true);
        isVisible = true;
    }

    void HideImage()
    {
        totalSilence.gameObject.SetActive(false);
        isVisible = false;
    }
}
