using System.Collections.Generic;
using Enum;
using UnityEngine;

public class S_RoomScript : MonoBehaviour
{
    
    public GameObject _leftDoor ;
    public GameObject _rightDoor ;
    public GameObject _leftUpDoor ;
    public GameObject _rightUpDoor ;

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

        if (_roomType == E_RoomType.BigRoom)
        {
            foreach (GameObject stairs in _stairsRef)
            {
                stairs.SetActive(false);
            }
            _stairsRef[Random.Range(0, _stairsRef.Count)].SetActive(true);
        }
        
        if (_leftUpDoor != null && _rightUpDoor != null && _roomType == E_RoomType.BigRoom)
        {
            _leftUpDoor.SetActive(false);
            _rightUpDoor.SetActive(false);
        }
        _leftDoor.SetActive(false);
        _rightDoor.SetActive(false);
        
    }

    private void CreationDoor()
    {
        if (!_roomOnLeft)
        {
            _leftDoor.SetActive(true);
        }

        if (!_roomOnRight)
        {
            _rightDoor.SetActive(true);
        }
    }
}