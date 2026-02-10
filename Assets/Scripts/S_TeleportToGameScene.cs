using Unity.VisualScripting;
using UnityEngine;

public class S_TeleportToGameScene : MonoBehaviour
{
    private GameObject _player;
    private S_CharacterCollisionHandler _collisionHandler;
    
    public string levelToLoadName;

    private void OnTriggerEnter(Collider collision)
    {
        if (_player != null && collision.gameObject.GameObject() == _player)
        {
            _collisionHandler.teleportToGameSceneRef = this;
            return;
        }

        if (collision.gameObject.tag == "MainCharacter")
        {
            _player = collision.gameObject;
            _collisionHandler = _player.GetComponent<S_CharacterCollisionHandler>();
            _collisionHandler.teleportToGameSceneRef = this;
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
