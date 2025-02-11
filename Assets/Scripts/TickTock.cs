using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickTock : MonoBehaviour
{

    void Update()
    {
        // Hämta aktuell sekund från systemklockan
        int seconds = System.DateTime.Now.Second;
        int milliseconds = System.DateTime.Now.Millisecond;

        // Beräkna exakt rotation i grader
        float rotationX = -(seconds * -6f + (milliseconds / 1000f) * -6f);

        // Ställ in rotation baserat på systemtiden
        transform.eulerAngles = new Vector3(rotationX, 0, 0);
    }
}

