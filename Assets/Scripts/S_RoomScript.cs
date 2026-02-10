using System.Collections.Generic;
using Enum;
using UnityEngine;

public class S_RoomScript : MonoBehaviour
{
    
    public List<GameObject> _leftDoor ;
    public List<GameObject> _rightDoor ;
    public List<GameObject> _leftUpDoor ;
    public List<GameObject> _rightUpDoor ;

    [SerializeField] private E_RoomType _roomType;
    [SerializeField] private E_SpecialRoom _specialRoomtype;
    
    [SerializeField] private List<GameObject> _stairsRef;

    private bool _roomOnLeft = false;
    private bool _roomOnRight = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (_leftDoor == null || _rightDoor == null)
        {
            Debug.Log("You forgot to add a door reference");
        }

        if (_roomType == E_RoomType.BigRoom && _stairsRef != null)
        {
            foreach (GameObject stairs in _stairsRef)
            {
                stairs.SetActive(false);
            }
            _stairsRef[Random.Range(0, _stairsRef.Count)].SetActive(true);
        }
        
        if (_leftUpDoor != null && _rightUpDoor != null && _roomType == E_RoomType.BigRoom)
        {
            foreach(GameObject featuresAtLeftUpDoor in _leftUpDoor) featuresAtLeftUpDoor.SetActive(false);
            foreach(GameObject featuresAtRightUpDoor in _rightUpDoor) featuresAtRightUpDoor.SetActive(false);
        }
        foreach (GameObject featuresAtLeftDoor  in _leftDoor) featuresAtLeftDoor.SetActive(false);
        foreach (GameObject featuresAtRightDoor  in _rightDoor) featuresAtRightDoor.SetActive(false);

        if (_roomType == E_RoomType.BigRoom)
        {
            CreationDoorForBigRoom();
            return;
        }
        CreationDoorForSmallAndMediumRoom();
    }

    private void CreationDoorForSmallAndMediumRoom()
    {
        if (_roomOnLeft)
        {
            foreach (GameObject featuresAtRightDoor  in _leftDoor) featuresAtRightDoor.SetActive(true);
        }

        if (_roomOnRight)
        {
            foreach (GameObject featuresAtRightDoor  in _rightDoor) featuresAtRightDoor.SetActive(true);
        }
    }
    
    private void CreationDoorForBigRoom()
    {
        if (_roomOnLeft)
        {
            foreach (GameObject featuresAtLeftUpDoor  in _leftUpDoor) featuresAtLeftUpDoor.SetActive(true);
        }

        if (_roomOnRight)
        {
            foreach (GameObject featuresAtRightUpDoor  in _rightUpDoor) featuresAtRightUpDoor.SetActive(true);
        }
    }
}