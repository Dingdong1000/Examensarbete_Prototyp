using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepTrigger : MonoBehaviour
{
    [SerializeField] private float rateWalk;
    [SerializeField] private GameObject player;
    [SerializeField] private FirstPersonController controller;
    public PlayerAudio playerAudio;
    float time;

    void Update()
    {
        time += Time.deltaTime;
        if (controller.isWalking)
            
        {
            if (time >= rateWalk)
            {
                time = 0;
                

                RaycastHit hit;
                Physics.Raycast(player.transform.position, Vector3.down, out hit, 1.5f);
                Debug.DrawRay(player.transform.position, Vector3.down*1f, Color.blue,1f);
               
                playerAudio.PlayerWalkAudio(player, hit.collider.tag);

            }
            
            
        }
    }
   
    
}
