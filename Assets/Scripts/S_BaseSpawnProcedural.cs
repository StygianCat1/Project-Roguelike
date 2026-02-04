using UnityEngine;

public class S_BaseSpawnProcedural : MonoBehaviour
{
    [SerializeField] private GameObject _prefabSpawnUp;
    [SerializeField] private GameObject _prefabSpawnDown;
    
    [SerializeField] private Vector3 _sizeRoomSize;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_prefabSpawnUp == null || _prefabSpawnDown == null)
        {
            Debug.LogError("Prefab Spawn Up or Spawn Down are required.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if (_prefabSpawnUp != null)
        { 
            Gizmos.color = Color.green; 
            Gizmos.DrawWireCube(new Vector3(_prefabSpawnUp.transform.position.x, _prefabSpawnUp.transform.position.y + (_sizeRoomSize.y /2.0f), _prefabSpawnUp.transform.position.z), _sizeRoomSize);            
        }

        if (_prefabSpawnDown != null)
        { 
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(new Vector3(_prefabSpawnDown.transform.position.x, _prefabSpawnDown.transform.position.y + (_sizeRoomSize.y /2.0f), _prefabSpawnDown.transform.position.z), _sizeRoomSize);    
        }

        if (_prefabSpawnUp != null || _prefabSpawnDown != null)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(_prefabSpawnUp.transform.position, _prefabSpawnDown.transform.position);    
        }
        
        
    }
}
