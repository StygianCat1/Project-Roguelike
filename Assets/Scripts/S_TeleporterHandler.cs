using System.Collections.Generic;
using UnityEngine;

public class S_TeleporterHandler : MonoBehaviour
{
    public S_BaseSpawnProcedural spawnProcedural;
    
    [Range(1,10)] public int numberOfFloorToReach = 1; 
    public int floorNumber;
    
    [SerializeField] private List<GameObject> teleporters;
    [SerializeField] private GameObject lastTpLocation;
    public GameObject canvasToSpawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        spawnProcedural = gameObject.GetComponent<S_BaseSpawnProcedural>();
        AddRefToTeleporters();
    }

    public void ChangeRefToFinalTeleporter()
    {
        foreach (GameObject teleporter in teleporters)
        {
            canvasToSpawn = null;
            teleporter.GetComponent<S_Teleporter>().tpLocation = lastTpLocation;
        }
    }

    private void AddRefToTeleporters()
    {
        foreach (GameObject teleporter in teleporters)
        {
            teleporter.GetComponent<S_Teleporter>()._teleporterHandler = this;
        }
    }

    public void AddEnemyRefToTeleport()
    {
        foreach (GameObject teleporter in teleporters)
        {
            teleporter.GetComponent<S_Teleporter>().enemyList.AddRange(spawnProcedural.totalEnemySpawned);
        }
    }
}
