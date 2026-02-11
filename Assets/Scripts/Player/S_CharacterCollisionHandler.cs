using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_CharacterCollisionHandler : MonoBehaviour
{
    public Teleporter teleporterRef;  
    public S_TeleportToGameScene teleportToGameSceneRef;
    
    private S_Rogue_Inputs _inputsManager;
    private S_Rogue_Combat _rogueCombat;
    
    private void Start()
    {
        _inputsManager = GetComponentInParent<S_Rogue_Inputs>();
    }

    private void Update()
    {
        if (_inputsManager.interact)
        {
            if (teleporterRef != null && teleporterRef.tpLocation != null)
            {
                transform.position = teleporterRef.tpLocation.transform.position;
                teleporterRef.IncrementTeleporter();
                teleporterRef = null;
            }

            if (teleportToGameSceneRef != null && teleportToGameSceneRef.levelToLoadName != null)
            {
                SceneManager.LoadScene(teleportToGameSceneRef.levelToLoadName);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
