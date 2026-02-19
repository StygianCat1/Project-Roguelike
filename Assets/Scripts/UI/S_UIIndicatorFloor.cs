using System;
using UnityEngine;

public class S_UIIndicatorFloor : MonoBehaviour
{
    public GameObject buttonElevatorFloor2;
    public GameObject buttonElevatorFloor3;
    public GameObject buttonElevatorFloor4;
    public GameObject buttonElevatorFloorBoss;

    private GameObject _teleporterHandlerRef;
    private S_TeleporterHandler _teleporterHandler;

    private void Start()
    {
        _teleporterHandlerRef = GameObject.FindGameObjectWithTag("MainHandler");
        _teleporterHandler = _teleporterHandlerRef.GetComponent<S_TeleporterHandler>();
        
        buttonElevatorFloor2.SetActive(false);
        buttonElevatorFloor3.SetActive(false);
        buttonElevatorFloor4.SetActive(false);
        buttonElevatorFloorBoss.SetActive(false);
    }

    private void Update()
    {
        if (_teleporterHandler.floorNumber == 1)
        {
            buttonElevatorFloor2.SetActive(true);
        }

        if (_teleporterHandler.floorNumber == 2)
        {
            buttonElevatorFloor3.SetActive(true);
        }

        if (_teleporterHandler.floorNumber == 3)
        {
            buttonElevatorFloor4.SetActive(true);
        }

        if (_teleporterHandler.floorNumber == 4)
        {
            buttonElevatorFloorBoss.SetActive(true);
        }
    }
}
    
