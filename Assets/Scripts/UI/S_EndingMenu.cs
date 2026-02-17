using UnityEngine;
using UnityEngine.SceneManagement;

public class S_EndingMenu : MonoBehaviour
{
    [SerializeField] private string _mainMenuSceneName;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(_mainMenuSceneName);
    }
}
