using System.Collections.Generic;
using UnityEngine;
    
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
    
    public List<ObjectDrop> objectDrops;
    private List<GameObject> _objectsToDrop;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        int _randomDropRate;
        foreach (ObjectDrop objectDrop in objectDrops)
        {
            _randomDropRate = Random.Range(0, 100);
            if (_randomDropRate <= objectDrop.dropRate)
            {
                Debug.Log(objectDrop.gameObject.name);
                _objectsToDrop.Add(objectDrop.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
