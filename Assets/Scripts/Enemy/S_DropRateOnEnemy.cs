using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class ObjectDrop
{
    public GameObject gameObject;
    [Range(0,100)] public int dropRate;

    public ObjectDrop(GameObject gameObject, int dropRate)
    {
        this.gameObject = gameObject;
        this.dropRate = dropRate;
    }
}
public class S_DropRateOnEnemy : MonoBehaviour
{
    private GameObject _playerRef;
    
    public List<ObjectDrop> objectDrops;
    private List<GameObject> _objectsToDropAtDeath;
    
    [SerializeField][Range(0, 100)] private int moneyDropRate = 50;
    [SerializeField][Range(0, 300)] public int minDropMoney = 50, maxDropMoney = 250;

    private void Start()
    {
        _playerRef = GameObject.FindGameObjectWithTag("MainCharacter");
    }
    
    public void DropMoney()
    {
        int moneyDrop = Random.Range(minDropMoney, maxDropMoney);
        if (moneyDropRate <= Random.Range(0, 100))
        {
            Debug.Log("money earned");
            _playerRef.GetComponent<S_Resources>().AddInGameMoney(moneyDrop);
        }
    }
    
    public void DropRateChoice()
    {
        int _randomDropRate;
        foreach (ObjectDrop objectDrop in objectDrops)
        {
            _randomDropRate = Random.Range(0, 100);
            if (_randomDropRate <= objectDrop.dropRate)
            {
                Debug.Log(objectDrop.gameObject.name);
                _objectsToDropAtDeath.Add(objectDrop.gameObject);
            }
        }
    }
}
