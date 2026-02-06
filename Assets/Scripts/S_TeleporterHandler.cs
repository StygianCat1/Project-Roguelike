using System.Collections.Generic;
using UnityEngine;

public class S_TeleporterHandler : MonoBehaviour
{

    
    [Range(1,10)] public int numberOfFloorToReach = 1; 
    public int floorNumber;
    
    [SerializeField] private List<GameObject> teleporters;
    [SerializeField] private GameObject lastTpLocation;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        AddRefToTeleporters();
    }

    public void ChangeRefToFinalTeleporter()
    {
        foreach (GameObject teleporter in teleporters)
        {
            teleporter.GetComponent<Teleporter>().tpLocation = lastTpLocation;
        }
    }

    private void AddRefToTeleporters()
    {
        foreach (GameObject teleporter in teleporters)
        {
            teleporter.GetComponent<Teleporter>()._teleporterHandler = this;
        }
    }
}
