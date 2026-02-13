using System.Collections.Generic;
using Enum;
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
    [SerializeField] private int _cutRoomVertically = 2;
    [SerializeField] private int _cutRoomHorizontally = 2;
    
    [SerializeField] private GameObject _prefabSpawnUp;
    [SerializeField] private GameObject _prefabSpawnDown;
    
    [SerializeField] private List<GameObject> _prefabSmallRoom;
    [SerializeField] private List<GameObject> _prefabSpecialRoom;
    [SerializeField] private List<GameObject> _prefabMediumRoom;
    [SerializeField] private List<GameObject> _prefabBigRoom;
    
    [SerializeField] private Vector2 _prefabSmallRoomSize;
    [SerializeField] private Vector2 _prefabMediumRoomSize;
    [SerializeField] private Vector2 _prefabBigRoomSize;
    
    [SerializeField] private float _prefabSmallRoomDropRate;
    [SerializeField] private float _prefabMediumRoomDropRate;
    [SerializeField] private float _prefabBigRoomDropRate;
    
    [SerializeField] private Vector3 _sizeRoomSize;
    [SerializeField][Tooltip("Use it as an offset to align to the place with the perfect point")] private Vector3 _offsetRoomSize;
    
    private List<GameObject> _roomsThatSpawnRef;
    
    public E_SpecialRoom specialRoomToSpawn = E_SpecialRoom.None; 
    private GameObject _prefabToDestroy;
    
    private List<Room> _roomsToCut;
    private List<Room> _roomsTotal;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_prefabSpawnUp == null || _prefabSpawnDown == null)
        {
            Debug.LogError("Prefab Spawn Up or Spawn Down is missing, or even both prefabs are missing.");
            return;
        }
        DefineRoom(_prefabSpawnDown);
    }

    public void DefineRoom(GameObject prefab)
    {
        Room rootRoom = new Room();
        rootRoom.Size = _sizeRoomSize;
        rootRoom.Center = new Vector3(prefab.transform.position.x + _offsetRoomSize.x, prefab.transform.position.y + (_sizeRoomSize.y /2.0f) + _offsetRoomSize.y, prefab.transform.position.z + _offsetRoomSize.z);;
        
        _roomsTotal = new List<Room>();
        
        _roomsToCut = new List<Room>();
        _roomsToCut.Add(rootRoom);
        
        _roomsThatSpawnRef = new List<GameObject>();
        
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
        ChosePrefab(prefab);
    }

    private void ChosePrefab(GameObject prefabToCut)
    {
        List<List<bool>> roomsToUse = new List<List<bool>>();
        
        for (int i = 0; i < _cutRoomHorizontally; i++)
        {
            roomsToUse.Add(new List<bool> {false});
        }
        foreach (List<bool> listOfBools in roomsToUse)
        {
            for (int i = 0; i < _cutRoomVertically - 1; i++)
            {
                listOfBools.Add(false);
            }
        }
        
        if (_prefabSmallRoomDropRate + _prefabMediumRoomDropRate + _prefabBigRoomDropRate == 100)
        {
            for (int i = 0 ; i < roomsToUse.Count ; i++)
            {
                for (int j = 0 ; j < roomsToUse[i].Count ; j++)
                { 
                    if (roomsToUse[i][j]) 
                    { 
                        continue; 
                    }
                    while (!roomsToUse[i][j])
                    {
                        int randomNumber = Random.Range(0, 100);
                        int numberVerify = 0;
                        if (randomNumber < _prefabSmallRoomDropRate)
                        { 
                            bool needRightWall = false;
                            bool needLeftWall = false;
                            E_RoomHeight roomHeightCheck = E_RoomHeight.None;
                            for (int k = 0; k < _prefabSmallRoomSize.y; k++)
                            {
                                for (int l = 0; l < _prefabSmallRoomSize.x; l++)
                                { 
                                    roomsToUse[i+k][j+l] = true;
                                    if (i == 0) {roomHeightCheck = E_RoomHeight.Low;}
                                    if (i == 1) { roomHeightCheck = E_RoomHeight.High;}
                                    if (i + k > 0 && j + l == 0) { needLeftWall = true;}
                                    if (i + k > 0 && j + l == roomsToUse[i].Count - 1) { needRightWall = true;}
                                    SpawnPrefab(_roomsTotal[i*_cutRoomVertically+j],_prefabSmallRoom[Random.Range(0, _prefabSmallRoom.Count)], needLeftWall, needRightWall, roomHeightCheck);
                                }
                            }
                        }
                        else if (randomNumber >= _prefabSmallRoomDropRate && randomNumber < _prefabSmallRoomDropRate + _prefabMediumRoomDropRate)
                        {
                            bool needRightWall = false;
                            bool needLeftWall = false;
                            E_RoomHeight roomHeightCheck = E_RoomHeight.None;
                            for (int k = 0; k < _prefabMediumRoomSize.y; k++)
                            {
                                for (int l = 0; l < _prefabMediumRoomSize.x; l++)
                                {
                                    if (i+k > roomsToUse.Count - 1 || j+l > roomsToUse[i].Count - 1)
                                    { 
                                        continue;
                                    }
                                    numberVerify++;
                                    if (i == 0) {roomHeightCheck = E_RoomHeight.Low;}
                                    if (i == 1) { roomHeightCheck = E_RoomHeight.High;}
                                    if (i+k > 0 && j+l == 0) { needLeftWall = true; }
                                    if (i+k > 0 && j+l == roomsToUse[i].Count - 1) { needRightWall = true; }
                                }
                            }
                            if (numberVerify == _prefabMediumRoomSize.y * _prefabMediumRoomSize.x)
                            {
                                 for (int k = 0; k < _prefabMediumRoomSize.y; k++) 
                                 {
                                     for (int l = 0; l < _prefabMediumRoomSize.x; l++)
                                     {
                                         roomsToUse[i+k][j+l] = true;
                                     }
                                 }
                                 SpawnPrefab(_roomsTotal[i*_cutRoomVertically+j],_prefabMediumRoom[Random.Range(0, _prefabMediumRoom.Count)], needLeftWall, needRightWall, roomHeightCheck);
                            }
                        }
                        else
                        {
                            bool needRightWall = false;
                            bool needLeftWall = false;
                            E_RoomHeight roomHeightCheck = E_RoomHeight.None;
                            for (int k = 0; k < _prefabBigRoomSize.y; k++)
                            {
                                for (int l = 0; l < _prefabBigRoomSize.x; l++)
                                { 
                                    if (i+k > roomsToUse.Count - 1 || j+l > roomsToUse[i].Count - 1) 
                                    {
                                        continue;
                                    }
                                    numberVerify++;
                                    if (i+k > 0 && j+l == 0) { needLeftWall = true; }
                                    if (i+k > 0 && j+l == roomsToUse[i].Count - 1) { needRightWall = true; }
                                }
                            }
                            if (numberVerify == _prefabBigRoomSize.y * _prefabBigRoomSize.x)
                            {
                                for (int k = 0; k < _prefabBigRoomSize.y; k++)
                                {
                                    for (int l = 0; l < _prefabBigRoomSize.x; l++)
                                    {
                                        roomsToUse[i+k][j+l] = true;
                                    }
                                } 
                                SpawnPrefab(_roomsTotal[i*_cutRoomVertically+j],_prefabBigRoom[Random.Range(0, _prefabBigRoom.Count)], needLeftWall, needRightWall, roomHeightCheck);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("Impossible to spawn rooms, need a total of 100 in drop rate to begin");
        }
        AddPrefabSpecialRoom(specialRoomToSpawn);
        Invoke(nameof(AddRoomTeleportRef), 0.5f);
    }

    private void SpawnPrefab(Room roomToSpawn, GameObject prefabToSpawn, bool leftdoor, bool rightdoor, E_RoomHeight roomHeight)
    {
        prefabToSpawn.GetComponent<S_RoomScript>()._doorOnLeft = leftdoor;
        prefabToSpawn.GetComponent<S_RoomScript>()._doorOnRight = rightdoor;
        prefabToSpawn.GetComponent<S_RoomScript>().roomHeight = roomHeight;
        _roomsThatSpawnRef.Add(Instantiate(prefabToSpawn, new Vector3(roomToSpawn.Center.x - (roomToSpawn.Size.x / 2), roomToSpawn.Center.y - (roomToSpawn.Size.y / 2), roomToSpawn.Center.z), prefabToSpawn.transform.rotation));
    }

    private void AddPrefabSpecialRoom(E_SpecialRoom roomTypeToSpawn)
    {
        if (roomTypeToSpawn == E_SpecialRoom.None){return;}
        bool foundSmallRoom = false;
        Vector3 posRef = new Vector3();

        for (int i = _roomsThatSpawnRef.Count - 1; i >= 0; i--)
        {
            if (_roomsThatSpawnRef[i].GetComponent<S_RoomScript>().roomType == E_RoomType.SmallRoom)
            {
                foundSmallRoom = true;
                posRef = _roomsThatSpawnRef[i].transform.position;
                Destroy(_roomsThatSpawnRef[i]);
                _roomsThatSpawnRef.Remove(_roomsThatSpawnRef[i]);
                break;
            }
        }
        
        if (foundSmallRoom == false)
        {
            for (int i = _roomsThatSpawnRef.Count - 1; i >= 0; i--)
            {
                if (_roomsThatSpawnRef[i].GetComponent<S_RoomScript>().roomType == E_RoomType.MediumRoom)
                {
                    posRef = _roomsThatSpawnRef[i].transform.position;
                    Destroy(_roomsThatSpawnRef[i]);
                    _roomsThatSpawnRef.Remove(_roomsThatSpawnRef[i]);
                    break;
                }
            }
        }

        GameObject specialroom = new GameObject();
        foreach (GameObject room in _prefabSpecialRoom)
        {
            if (room.GetComponent<S_RoomScript>().specialRoomtype == roomTypeToSpawn)
            {
                specialroom = room;
            }
        }
        if (foundSmallRoom)
        {
            _roomsThatSpawnRef.Add(Instantiate(specialroom, posRef, specialroom.transform.rotation)); 
            return;
        }
        _roomsThatSpawnRef.Add(Instantiate(specialroom, posRef, specialroom.transform.rotation));
        int randomNumber = Random.Range(0, _prefabSmallRoom.Count);
        _roomsThatSpawnRef.Add(Instantiate(_prefabSmallRoom[randomNumber],new Vector3(posRef.x + 9f, posRef.y, posRef.z) , _prefabSmallRoom[randomNumber].transform.rotation));
    }

    private void AddRoomTeleportRef()
    {
        foreach (GameObject room in _roomsThatSpawnRef)
        {
            if (room.GetComponent<S_RoomScript>()._tpInRoom == null) {continue;}
            room.GetComponent<S_RoomScript>()._tpInRoom.SearchForCloseTp();
        }
    }
    
    public void DestroyPrefab()
    {
        foreach (GameObject roomToDestroy in _roomsThatSpawnRef)
        { 
            Destroy(roomToDestroy);   
        }
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
    }
}
