using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

[CreateAssetMenu(menuName = "ScriptableObejcts/Audio/Player")]

public class PlayerAudio : ScriptableObject
{
    [SerializeField] private EventReference playerWalk, playerJumpLand;
    [SerializeField] private EventReference playerVisceral;

    [SerializeField] private EventReference introVoice;

    /*public void PlayerWalkAudio(GameObject player)
    {
        RuntimeManager.PlayOneShotAttached(playerWalk,player);
    }*/

public void PlayerWalkAudio(GameObject walkObj, string surface)
    {
        EventInstance playerWalkInstance = RuntimeManager.CreateInstance(playerWalk);
        RuntimeManager.AttachInstanceToGameObject(playerWalkInstance, walkObj.transform);

        switch (surface)
        {
            case "Concrete":
                playerWalkInstance.setParameterByName("Surface", 0f);
                break;
            case "Concrete Water":
                playerWalkInstance.setParameterByName("Surface", 1f);
                break;
            case "Concrete Dirt":
                playerWalkInstance.setParameterByName("Surface", 2f);
                break;
            case "Garbage":
                playerWalkInstance.setParameterByName("Surface", 3f);
                break;
            case "Player":
                break;
        }

        playerWalkInstance.start();
        playerWalkInstance.release();
    }
    
public void PlayerJumpLandAudio(GameObject jumpLandObj, string surface)
{
    EventInstance playerJumpLandInstance = RuntimeManager.CreateInstance(playerJumpLand);
    RuntimeManager.AttachInstanceToGameObject(playerJumpLandInstance, jumpLandObj.transform);

    switch (surface)
    {
        case "Concrete":
            playerJumpLandInstance.setParameterByName("Surface", 0f);
            break;
        case "Concrete Water":
            playerJumpLandInstance.setParameterByName("Surface", 1f);
            break;
        case "Concrete Dirt":
            playerJumpLandInstance.setParameterByName("Surface", 2f);
            break;
        case "Garbage":
            playerJumpLandInstance.setParameterByName("Surface", 3f);
            break;
        case "Player":
            break;
    }

    playerJumpLandInstance.start();
    playerJumpLandInstance.release();
}

public void PlayerVisceralAudio()
{
            RuntimeManager.PlayOneShot(playerVisceral);
        }

public void IntroVoice()
{
    RuntimeManager.PlayOneShot(introVoice);
}
    
    
}