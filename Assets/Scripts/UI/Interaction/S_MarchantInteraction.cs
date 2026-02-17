using UnityEngine;

public class S_MarchantInteraction : MonoBehaviour
{
    private GameObject _player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void QuitUi()
    {
        Destroy(gameObject);
    }
}
