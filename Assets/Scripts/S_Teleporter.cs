using System;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class S_Teleporter : MonoBehaviour
{
    public GameObject tpLocation;
    [HideInInspector] public S_TeleporterHandler _teleporterHandler;

    [SerializeField] private List<GameObject> _enemiesInZone;
    
    [SerializeField] private GameObject _roomToSpawn;
    
    [SerializeField] private S_BaseSpawnProcedural _spawnProcedural;
    
    private GameObject _player;
    private S_CharacterCollisionHandler _collisionHandler;

    

    private void Start()
    {
        if (tpLocation == null)
        {
            Debug.LogError("Teleporter: tpLocation is null");
        }
    }

    public void IncrementTeleporter()
    {
        _teleporterHandler.floorNumber += 1;
        if (_teleporterHandler.floorNumber == _teleporterHandler.numberOfFloorToReach)
        {
            Debug.Log("Teleporter: Reached the end of the floor");
            _teleporterHandler.ChangeRefToFinalTeleporter();
        }
    }

    public void SpawnRoomAndDestroyOther()
    {
        _spawnProcedural.DestroyPrefab();
        _spawnProcedural.DefineRoom(_roomToSpawn);
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
