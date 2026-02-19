using System;
using UnityEngine;

public class S_UIIndicatorFloor : MonoBehaviour
{
    public GameObject ButtonElevatorFloor2;
    public GameObject ButtonElevatorFloor3;
    public GameObject ButtonElevatorFloor4;
    public GameObject ButtonElevatorFloorBoss;
    S_TeleporterHandler teleporterHandler;
    
    [SerializeField] GameObject teleporterHandlerRef;

    void Awake()
    {
        teleporterHandler = teleporterHandlerRef.GetComponent<S_TeleporterHandler>();
    }

    private void Update()
    {
        
    }

    public void PopElevatorFloor2()
    {
        if (teleporterHandler.floorNumber == 2)
        {
            ButtonElevatorFloor2.SetActive(true);
        }
        
    }
    
    public void PopElevatorFloor3()
    
    
    {
        if (teleporterHandler.floorNumber == 3)
        {
            ButtonElevatorFloor3.SetActive(true);
        }
        
    }
    
    public void PopElevatorFloor4()
    {
        if (teleporterHandler.floorNumber == 4)
        {
            ButtonElevatorFloor4.SetActive(true);
        }
        
    }
    
    public void PopElevatorFloorBoss()
    {
        if (teleporterHandler.floorNumber == 5)
        {
            ButtonElevatorFloorBoss.SetActive(true); 
        }
        
    }



}
