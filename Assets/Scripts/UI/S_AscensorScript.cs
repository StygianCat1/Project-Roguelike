using Enum;
using UnityEngine;

public class S_AscensorScript : MonoBehaviour
{
    public S_Teleporter teleporterUsed;
    private GameObject _mainHandler;
    private S_TeleporterHandler _sTeleporterHandler;
    private S_BaseSpawnProcedural _sBaseSpawnProcedural; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _mainHandler = GameObject.FindGameObjectWithTag("MainHandler");
        _sTeleporterHandler = _mainHandler.GetComponent<S_TeleporterHandler>();
        _sBaseSpawnProcedural = _mainHandler.GetComponent<S_BaseSpawnProcedural>();
        Time.timeScale = 0;
    }

    public void ChangeToGamblingMachine()
    {
        _sBaseSpawnProcedural.specialRoomToSpawn = E_SpecialRoom.Pachinko;
        teleporterUsed.SpawnRoomAndDestroyOther();
        Time.timeScale = 1;
        Destroy(gameObject);
    }
    
    public void ChangeToBar()
    {
        _sBaseSpawnProcedural.specialRoomToSpawn = E_SpecialRoom.Bar;
        teleporterUsed.SpawnRoomAndDestroyOther();
        Time.timeScale = 1;
        Destroy(gameObject);
    }
    
    public void ChangeToVendingMachine()
    {
        _sBaseSpawnProcedural.specialRoomToSpawn = E_SpecialRoom.VendingMachine;
        teleporterUsed.SpawnRoomAndDestroyOther();
        Time.timeScale = 1;
        Destroy(gameObject);
        
    }
}
