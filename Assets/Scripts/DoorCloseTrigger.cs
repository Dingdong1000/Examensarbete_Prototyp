using UnityEngine;

public class DoorCloseTrigger : MonoBehaviour
{
    public GameObject doorToClose;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hej");
            doorToClose.SetActive(true);
        }
    }
}
