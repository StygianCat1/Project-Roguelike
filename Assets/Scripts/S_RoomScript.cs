using System.Collections.Generic;
using Enum;
using UnityEngine;

public class S_RoomScript : MonoBehaviour
{
    public List<GameObject> _leftDoor ;
    public List<GameObject> _rightDoor ;
    public List<GameObject> _leftUpDoor ;
    public List<GameObject> _rightUpDoor ;

    public E_RoomHeight roomHeight;
    public E_RoomType roomType;
    public E_SpecialRoom specialRoomtype;
    
    [SerializeField] private List<GameObject> _stairsRef;
    public S_RoomTeleporter _tpInRoom;

    public bool _doorOnLeft = false;
    public bool _doorOnRight = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (_leftDoor == null || _rightDoor == null)
        {
            Debug.Log("You forgot to add a door reference");
        }

        if (roomType == E_RoomType.BigRoom && _stairsRef.Count != 0)
        {
            foreach (GameObject stairs in _stairsRef)
            {
                stairs.SetActive(false);
            }
            _stairsRef[Random.Range(0, _stairsRef.Count)].SetActive(true);
        }
        
        if (_leftUpDoor != null && _rightUpDoor != null && roomType == E_RoomType.BigRoom)
        {
            foreach(GameObject featuresAtLeftUpDoor in _leftUpDoor) featuresAtLeftUpDoor.SetActive(false);
            foreach(GameObject featuresAtRightUpDoor in _rightUpDoor) featuresAtRightUpDoor.SetActive(false);
        }
        foreach (GameObject featuresAtLeftDoor  in _leftDoor) featuresAtLeftDoor.SetActive(false);
        foreach (GameObject featuresAtRightDoor  in _rightDoor) featuresAtRightDoor.SetActive(false);

        if (_tpInRoom != null)
        {
            _tpInRoom.roomHeight = roomHeight;
        }
        
        if (roomHeight == E_RoomHeight.High) {_tpInRoom.roomHeight = E_RoomHeight.Low;}
        if (roomHeight == E_RoomHeight.Low) {_tpInRoom.roomHeight = E_RoomHeight.High;}
        
        
        if (roomType == E_RoomType.BigRoom)
        {
            CreationDoorForBigRoom();
            return;
        }
        CreationDoorForSmallAndMediumRoom();
    }

    public void CreationDoorForSmallAndMediumRoom()
    {
        if (_doorOnLeft)
        {
            foreach (GameObject featuresAtRightDoor  in _leftDoor) featuresAtRightDoor.SetActive(true);
        }

        if (_doorOnRight)
        {
            foreach (GameObject featuresAtRightDoor  in _rightDoor) featuresAtRightDoor.SetActive(true);
        }
    }
    
    public void CreationDoorForBigRoom()
    {
        if (_doorOnLeft)
        {
            foreach (GameObject featuresAtLeftUpDoor  in _leftUpDoor) featuresAtLeftUpDoor.SetActive(true);
        }

        if (_doorOnRight)
        {
            foreach (GameObject featuresAtRightUpDoor  in _rightUpDoor) featuresAtRightUpDoor.SetActive(true);
        }
    }
}