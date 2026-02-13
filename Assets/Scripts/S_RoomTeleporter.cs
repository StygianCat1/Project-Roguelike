using System.Collections.Generic;
using Enum;
using Unity.VisualScripting;
using UnityEngine;

public class S_RoomTeleporter : MonoBehaviour
{
    public GameObject tpLocation;
    public E_RoomHeight roomHeight = E_RoomHeight.None;
    
    [SerializeField] private S_TpRoomPoint _tpToNotUse;
    [SerializeField] private GameObject _tpRoom;
    
    
    private GameObject _player;
    private S_CharacterCollisionHandler _collisionHandler;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (roomHeight == E_RoomHeight.High) {_tpToNotUse.roomHeight = E_RoomHeight.Low;}
        if (roomHeight == E_RoomHeight.Low) {_tpToNotUse.roomHeight = E_RoomHeight.High;}
    }
    
    public void SearchForCloseTp()
    {
        List<GameObject> tpList = new List<GameObject>();
        GameObject tp = new GameObject();
        float tpDistance = 0;
        tpList.AddRange(GameObject.FindGameObjectsWithTag("Teleporter"));
        if (tpList.Count == 0)
        {
            Debug.Log("No teleporter found");
            return;
        }
        for (int i = 0; i < tpList.Count; i++)
        {
            if (tpList[i].GetComponent<S_TpRoomPoint>() == _tpToNotUse) { continue; }
            if (tpList[i].GetComponent<S_TpRoomPoint>().roomHeight != roomHeight){ continue;}
            if (tpDistance == 0)
            {
                tp = tpList[i];
                tpDistance = Vector3.Distance(transform.position, tpList[i].transform.position);
                continue;
            }

            if (tpDistance > Vector3.Distance(transform.position, tpList[i].transform.position))
            {
                tp = tpList[i];
                tpDistance = Vector3.Distance(transform.position, tpList[i].transform.position);
            }
        }
        tpLocation = tp;
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (_player != null && collision.gameObject.GameObject() == _player)
        {
            _collisionHandler.roomTeleporterRef = this;
            return;
        }
        if (collision.gameObject.tag == "MainCharacter")
        {
            _player = collision.gameObject;
            _collisionHandler = _player.GetComponent<S_CharacterCollisionHandler>();
            _collisionHandler.roomTeleporterRef = this;
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
