using System;
using UnityEngine;

public class S_UIIndicatorFloor : MonoBehaviour
{
    public GameObject buttonElevatorFloor2;
    public GameObject buttonElevatorFloor3;
    public GameObject buttonElevatorFloor4;
    public GameObject buttonElevatorFloorBoss;
    S_TeleporterHandler teleporterHandler;

    [SerializeField] GameObject teleporterHandlerRef;

    void Awake()
    {
        teleporterHandler = teleporterHandlerRef.GetComponent<S_TeleporterHandler>();
    }

    void Start()
    {
        buttonElevatorFloor2.SetActive(false);
        buttonElevatorFloor3.SetActive(false);
        buttonElevatorFloor4.SetActive(false);
        buttonElevatorFloorBoss.SetActive(false);
    }

    private void Update()
    {
        if (teleporterHandler.floorNumber == 2)
        {
            buttonElevatorFloor2.SetActive(true);
        }

        if (teleporterHandler.floorNumber == 3)
        {
            buttonElevatorFloor3.SetActive(true);
        }

        if (teleporterHandler.floorNumber == 4)
        {
            buttonElevatorFloor4.SetActive(true);
        }

        if (teleporterHandler.floorNumber == 5)
        {
            buttonElevatorFloorBoss.SetActive(true);
        }
    }
}
    
