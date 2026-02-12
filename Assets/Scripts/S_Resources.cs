using System;
using UnityEngine;

public class S_Resources : MonoBehaviour
{
    [SerializeField] private int _resourcesInGame;
    public int _resourcesOutGame;

    private void Start()
    {
        _resourcesOutGame = S_GameManager.outGameMoneySave;
    }

    public void SaveResources()
    {
        S_GameManager.outGameMoneySave = _resourcesOutGame;
    }
}
