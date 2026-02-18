using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class S_DropRateOnEnemy : MonoBehaviour
{
    private GameObject _playerRef;
    
    [SerializeField][Range(0, 100)] private int moneyDropRate = 50;
    [SerializeField][Range(0, 300)] public int minDropMoney = 50, maxDropMoney = 250;

    private void Start()
    {
        _playerRef = GameObject.FindGameObjectWithTag("MainCharacter");
    }
    
    public void DropMoney()
    {
        int moneyDrop = Random.Range(minDropMoney, maxDropMoney) * _playerRef.GetComponent<S_Rogue_Bonus>().avidityMultiplier;
        if (moneyDropRate <= Random.Range(0, 100))
        {
            _playerRef.GetComponent<S_Resources>().AddInGameMoney(moneyDrop);
        }
    }
}
