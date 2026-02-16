using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_CharacterCollisionHandler : MonoBehaviour
{
    public S_Teleporter teleporterRef;  
    public  S_RoomTeleporter roomTeleporterRef;
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
                GameObject canvasRef = new GameObject();
                if (teleporterRef._teleporterHandler.canvasToSpawn != null)
                {
                    canvasRef = Instantiate(teleporterRef._teleporterHandler.canvasToSpawn);
                    canvasRef.GetComponent<S_AscensorScript>().teleporterUsed = teleporterRef;                    
                }
                transform.position = teleporterRef.tpLocation.transform.position;
                teleporterRef.IncrementTeleporter();
                teleporterRef = null;
                _inputsManager.interact = false;
                return;
            }

            if (roomTeleporterRef != null && roomTeleporterRef.tpLocation != null)
            {
                transform.position = roomTeleporterRef.tpLocation.transform.position;
                roomTeleporterRef = null;
                _inputsManager.interact = false;
                return;
            }

            if (teleportToGameSceneRef != null && teleportToGameSceneRef.levelToLoadName != null)
            {
                SceneManager.LoadScene(teleportToGameSceneRef.levelToLoadName);
                _inputsManager.interact = false;
                return;
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
