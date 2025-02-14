using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    private LightSequence controller;

    void Start()
    {
        // Hämta referens till LightSequenceController
        controller = FindObjectOfType<LightSequence>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            controller.PlayerEnteredLightZone();
        }
    }
}