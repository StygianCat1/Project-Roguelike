using Unity.VisualScripting;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private GameObject _player;
    private CharacterCollisionHandler _collisionHandler;
    public GameObject tpLocation;
    
    
    private void OnTriggerEnter(Collider collision)
    {
        if (_player != null && collision.gameObject.GameObject() == _player)
        {
            _collisionHandler.teleporterRef = this;
            return;
        }
        if (collision.gameObject.tag == "MainCharacter")
        {
            _player = collision.gameObject;
            _collisionHandler = _player.GetComponent<CharacterCollisionHandler>();
            _collisionHandler.teleporterRef = this;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (_player != null && collision.gameObject.GameObject() == _player)
        {
            _collisionHandler.teleporterRef = null;
        }
    }
}
