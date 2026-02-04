using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public GameObject tpLocation;

    [SerializeField] private List<GameObject> _enemiesInZone;
    [SerializeField][Tooltip("Only put the 'P_TpPoint' that you do not want to use in this list")] private List<GameObject> teleporterToNotUse;
    
    private GameObject _player;
    private S_CharacterCollisionHandler _collisionHandler;
    private List<GameObject> _teleporters;

    private void Start()
    {
        _teleporters = new List<GameObject>();
        if (tpLocation == null)
        {
            SearchTpPoints();
        }
    }

    private void SearchTpPoints()
    {
        List<GameObject> gameObjectsToRemove = new List<GameObject>();
        float minDistanceTpDistance = 0.0f;
        GameObject minDistanceTp = null;
        _teleporters.AddRange(GameObject.FindGameObjectsWithTag("TpPoint"));
        foreach (GameObject teleporterRef in _teleporters)
        {
            foreach (GameObject teleporterUnused in teleporterToNotUse)
            {
                if (teleporterUnused == teleporterRef)
                {
                    gameObjectsToRemove.Add(teleporterRef);
                }
            }
        }
        foreach (GameObject teleporterToremove in gameObjectsToRemove)
        {
            _teleporters.Remove(teleporterToremove);
        }
        foreach (GameObject teleporterLasting in _teleporters)
        {
            if (minDistanceTpDistance == 0f)
            {
                minDistanceTpDistance = Vector3.Distance(transform.position, teleporterLasting.transform.position);
                minDistanceTp = teleporterLasting;
                continue;
            }
            if (minDistanceTpDistance > Vector3.Distance(transform.position, teleporterLasting.transform.position))
            {
                minDistanceTpDistance = Vector3.Distance(transform.position, teleporterLasting.transform.position);
                minDistanceTp = teleporterLasting;
            }
            tpLocation = minDistanceTp;
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
