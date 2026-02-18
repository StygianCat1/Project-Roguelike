using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_CharacterCollisionHandler : MonoBehaviour
{
    public S_Teleporter teleporterRef;  
    public S_RoomTeleporter roomTeleporterRef;
    public S_TeleportToGameScene teleportToGameSceneRef;
    public S_InteractibleElement interactibleElementRef;
    public S_MerchantInteractible merchantInteractionRef;
    
    private S_Rogue_Inputs _inputsManager;
    private S_Rogue_Combat _rogueCombat;
    
    [SerializeField] GameObject _interactPromptRef;
    
    private void Start()
    {
        _inputsManager = GetComponentInParent<S_Rogue_Inputs>();
        _rogueCombat = GetComponentInParent<S_Rogue_Combat>();
    }

    private void Update()
    {
        if (teleporterRef != null || roomTeleporterRef != null || interactibleElementRef != null || merchantInteractionRef != null ||teleportToGameSceneRef != null){_interactPromptRef.SetActive(true); }
        else {_interactPromptRef.SetActive(false);}
        
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

            if (merchantInteractionRef != null)
            {
                merchantInteractionRef.ShowMerchantUi();
                _inputsManager.interact = false;
                return;
            }

            if (interactibleElementRef != null)
            {
                interactibleElementRef.LaunchInteraction();
                _inputsManager.interact = false;
                return;
            }

            if (teleportToGameSceneRef != null && teleportToGameSceneRef.levelToLoadName != null)
            {
                SceneManager.LoadScene(teleportToGameSceneRef.levelToLoadName);
                _inputsManager.interact = false;
            }
        }
    }
}
