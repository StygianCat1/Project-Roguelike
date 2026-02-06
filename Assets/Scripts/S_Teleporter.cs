using System;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public GameObject tpLocation;
    public S_TeleporterHandler _teleporterHandler;

    [SerializeField] private List<GameObject> _enemiesInZone;
    
    private GameObject _player;
    private S_CharacterCollisionHandler _collisionHandler;

    private void Start()
    {
        if (tpLocation == null)
        {
            Debug.LogError("Teleporter: tpLocation is null");
        }
    }


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
            _collisionHandler = _player.GetComponent<S_CharacterCollisionHandler>();
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

    private void OnDrawGizmos()
    {
        if (tpLocation != null)
        {
            Gizmos.DrawLine(transform.position, tpLocation.transform.position);
        }
    }
}
