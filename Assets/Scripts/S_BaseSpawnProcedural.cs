using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Room
{
    public Vector2 Size;
    public Vector3 Center;
    public GameObject InstanciatedChunk;
}

public class S_BaseSpawnProcedural : MonoBehaviour
{
    [SerializeField] private int _minRangeX = 9; 
    [SerializeField] private int _minRangeY = 6;
    [SerializeField] private int _maxRangeX = 27;
    [SerializeField] private int _maxRangeY = 12;
    
    [SerializeField] private int _cutRoomVertically = 2;
    [SerializeField] private int _cutRoomHorizontally = 2;
    
    [SerializeField] private GameObject _prefabSpawnUp;
    [SerializeField] private GameObject _prefabSpawnDown;
    
    [SerializeField] private List<GameObject> _prefabLittleRoom;
    [SerializeField] private List<GameObject> _prefabMiddleRoom;
    [SerializeField] private List<GameObject> _prefabBigRoom;
    
    [SerializeField] private Vector3 _sizeRoomSize;
    [SerializeField][Tooltip("Use it as an offset to align to the place with the perfect point")] private Vector3 _offsetRoomSize;
    
    private GameObject _prefabToDestroy;
    
    private List<Room> _roomsToCut ;
    private List<Room> _roomsTotal;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_prefabSpawnUp == null || _prefabSpawnDown == null)
        {
            Debug.LogError("Prefab Spawn Up or Spawn Down are required.");
            return;
        }
        DefineRoom(_prefabSpawnDown);
    }

    private void DefineRoom(GameObject prefab)
    {
        Room rootRoom = new Room();
        rootRoom.Size = _sizeRoomSize;
        rootRoom.Center = new Vector3(prefab.transform.position.x + _offsetRoomSize.x, prefab.transform.position.y + (_sizeRoomSize.y /2.0f) + _offsetRoomSize.y, prefab.transform.position.z + _offsetRoomSize.z);;
        
        _roomsTotal = new List<Room>();
        
        _roomsToCut = new List<Room>();
        _roomsToCut.Add(rootRoom);
        
        Room cuttableRoom = _roomsToCut[0];
        float newHeightHorizontal = _sizeRoomSize.y / _cutRoomHorizontally;
        for (int i = 0; i < _cutRoomHorizontally; i++)
        {
            Room roomUp = new Room();
            Room roomDown = new Room();
                
            roomDown.Size = new Vector2(cuttableRoom.Size.x, newHeightHorizontal);
            roomUp.Size = new Vector2(cuttableRoom.Size.x, cuttableRoom.Size.y - newHeightHorizontal);
                
            float offsetHorizontal  = (cuttableRoom.Size.y / 2) - (roomDown.Size.y / 2);
            roomDown.Center = new Vector3(cuttableRoom.Center.x, cuttableRoom.Center.y - offsetHorizontal, cuttableRoom.Center.z);
                
            offsetHorizontal = (cuttableRoom.Size.y / 2) - (roomUp.Size.y/ 2);
            roomUp.Center = new Vector3(cuttableRoom.Center.x, cuttableRoom.Center.y + offsetHorizontal, cuttableRoom.Center.z);

            cuttableRoom = roomUp; 
            _roomsToCut.Add(roomDown);
        }
        _roomsToCut.RemoveAt(0);
        
        float newWidthVertical = _sizeRoomSize.x / _cutRoomVertically;
        foreach (Room cutRoom in _roomsToCut)
        {
            cuttableRoom = cutRoom;
            for (int i = 0; i < _cutRoomVertically; i++)
            {
                Room roomLeft = new Room();
                Room roomRight = new Room();
                
                roomLeft.Size = new Vector2(newWidthVertical, cuttableRoom.Size.y);
                roomRight.Size = new Vector2(cuttableRoom.Size.x - newWidthVertical, cuttableRoom.Size.y);
                
                float offsetVertical  = (cuttableRoom.Size.x / 2) - (roomLeft.Size.x / 2);
                roomLeft.Center = new Vector3(cuttableRoom.Center.x - offsetVertical, cuttableRoom.Center.y, cuttableRoom.Center.z);
                
                offsetVertical = (cuttableRoom.Size.x / 2) - (roomRight.Size.x / 2);
                roomRight.Center = new Vector3(cuttableRoom.Center.x + offsetVertical, cuttableRoom.Center.y, cuttableRoom.Center.z);

                cuttableRoom = roomRight;
                _roomsTotal.Add(roomLeft);
            }
        }
    }

    private void CutSizeInPart(GameObject prefabToCut)
    {
        
    }

    private void DestroyPrefab(GameObject prefabToDestroy)
    {
        Destroy(prefabToDestroy);
    }


    private void OnDrawGizmos()
    {
        if (_prefabSpawnUp != null)
        { 
            Gizmos.color = Color.green; 
            Gizmos.DrawWireCube(new Vector3(_prefabSpawnUp.transform.position.x + _offsetRoomSize.x, _prefabSpawnUp.transform.position.y + (_sizeRoomSize.y /2.0f) + _offsetRoomSize.y, _prefabSpawnUp.transform.position.z + _offsetRoomSize.z), _sizeRoomSize);            
        }

        if (_prefabSpawnDown != null)
        { 
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(new Vector3(_prefabSpawnDown.transform.position.x + _offsetRoomSize.x, _prefabSpawnDown.transform.position.y + (_sizeRoomSize.y /2.0f) + _offsetRoomSize.y, _prefabSpawnDown.transform.position.z + _offsetRoomSize.z), _sizeRoomSize);    
        }
        
        if (_roomsTotal != null)
        {
            foreach (Room room in _roomsTotal)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawWireCube(new Vector3(room.Center.x, room.Center.y ,room.Center.z ), new Vector3(room.Size.x, room.Size.y, 0));
            }
        }
        
        if (_prefabSpawnUp != null || _prefabSpawnDown != null)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawLine(_prefabSpawnUp.transform.position, _prefabSpawnDown.transform.position);    
        }
    }
}
