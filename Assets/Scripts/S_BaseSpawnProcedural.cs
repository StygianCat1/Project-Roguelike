using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Room
{
    public Vector2 Size;
    public Vector2 Center;
    public GameObject InstanciatedChunk;
}

public class S_BaseSpawnProcedural : MonoBehaviour
{
    [SerializeField]private int _minRangeX = 9; 
    [SerializeField] private int _minRangeY = 6;
    [SerializeField]private int _maxRangeX = 27;
    [SerializeField]private int _maxRangeY = 12;
    
    [SerializeField] private GameObject _prefabSpawnUp;
    [SerializeField] private GameObject _prefabSpawnDown;
    
    [SerializeField] private List<GameObject> _prefabLittleRoom;
    [SerializeField] private List<GameObject> _prefabMiddleRoom;
    [SerializeField] private List<GameObject> _prefabBigRoom;
    
    [SerializeField] private Vector3 _sizeRoomSize;
    [SerializeField][Tooltip("Use it as an offset to align to the place with the perfect point")] private Vector3 _offsetRoomSize;
    
    private GameObject _prefabToDestroy;
    
    private List<Room> _roomsToCut ;
    private List<Room> _rooms;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_prefabSpawnUp == null || _prefabSpawnDown == null)
        {
            Debug.LogError("Prefab Spawn Up or Spawn Down are required.");
            return;
        }
        CutSizeInPart(_prefabSpawnDown);
    }

    private void DefineRoom(GameObject prefab)
    {
        Room rootRoom = new Room();
        _rooms = new List<Room>();
        _roomsToCut = new List<Room>();
        _roomsToCut.Add(rootRoom);
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

        if (_prefabSpawnUp != null || _prefabSpawnDown != null)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(_prefabSpawnUp.transform.position, _prefabSpawnDown.transform.position);    
        }
        
        
    }
}
