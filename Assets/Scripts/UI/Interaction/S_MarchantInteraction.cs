using UnityEngine;

public class S_MarchantInteraction : MonoBehaviour
{
    private GameObject _player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Time.timeScale = 0f;
        _player = GameObject.FindGameObjectWithTag("MainCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void QuitUi()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
