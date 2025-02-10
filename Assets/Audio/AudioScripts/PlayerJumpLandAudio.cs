using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpLandAudio : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private FirstPersonController controller;
    public PlayerAudio playerAudio;
  
    
        
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            Physics.Raycast(player.transform.position, Vector3.down, out hit, 1.5f);
            Debug.DrawRay(player.transform.position, Vector3.down*1f, Color.blue,1f);
            Debug.Log("Ray hit:" + hit.collider.tag);
            playerAudio.PlayerJumpLandAudio(player, hit.collider.tag); 
        }
    }
}
