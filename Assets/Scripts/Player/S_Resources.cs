using System;
using UnityEngine;

public class S_Resources : MonoBehaviour
{
    public int _resourcesInGame;
    public int _resourcesOutGame;

    private void Start()
    {
        _resourcesOutGame = S_GameManager.outGameMoneySave / 2;
    }

    public void AddInGameMoney(int amount)
    {
        _resourcesInGame += amount;
    } 

    public void SaveResources()
    {
        S_GameManager.outGameMoneySave = _resourcesOutGame;
    }
}
