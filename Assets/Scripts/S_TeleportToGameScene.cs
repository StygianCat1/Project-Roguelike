using System;
using Unity.VisualScripting;
using UnityEngine;

public class S_TeleportToGameScene : MonoBehaviour
{
    private GameObject _player;
    private S_CharacterCollisionHandler _collisionHandler;
    
    public string levelToLoadName;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCharacter");
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "MainCharacter")
        {
            _collisionHandler = _player.GetComponent<S_CharacterCollisionHandler>();
            _collisionHandler.teleportToGameSceneRef = this;
            S_GameManager.outGameMoneySave = _player.GetComponent<S_Resources>()._resourcesOutGame;
        }
    }
    
    private void OnTriggerExit(Collider collision)
    {
        if (_player != null && collision.gameObject.GameObject() == _player)
        {
            _collisionHandler.teleportToGameSceneRef = null;
        }
    }
}
