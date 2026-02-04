using Enum;
using UnityEngine;

public class S_RoomScript : MonoBehaviour
{
    
    public GameObject _leftDoor ;
    public GameObject _rightDoor ;

    [SerializeField] private E_RoomType _roomType;
    [SerializeField] private E_SpawnLocation _spawnLocation;

    private bool _roomOnLeft = false;
    private bool _roomOnRight = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Debug.Log(_roomType);
        if (_leftDoor == null || _rightDoor == null)
        {
            Debug.Log("You forgot to add a door reference");
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
