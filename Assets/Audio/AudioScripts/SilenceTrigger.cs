using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilenceTrigger : MonoBehaviour
{
    [SerializeField] public int switchValue;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Sound Switch", switchValue);
            Debug.Log("Sound Switch updated to: " + switchValue);
        }
    }
}
