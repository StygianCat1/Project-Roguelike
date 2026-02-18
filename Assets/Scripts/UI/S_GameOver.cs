using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameOver : MonoBehaviour
{
    private GameObject player;
    [SerializeReference] private string _mainMenuSceneName;
    [SerializeReference] private string _hubSceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCharacter");
        S_GameManager.outGameMoneySave = player.GetComponent<S_Resources>()._resourcesOutGame;
        S_GameManager.luckyGamblerUpgradeLevelSave = 0;
        S_GameManager.avidityUpgradeLevelSave = 0;
        S_GameManager.angryKaoriUpgradeLevelSave = 0;
        S_GameManager.luckyShotCooldownSave = 0;
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(_mainMenuSceneName);
    }
    
    public void GoBackToHub()
    {
        SceneManager.LoadScene(_hubSceneName);
    }
    
    
    public void QuitGame()
    {
        Application.Quit();
    }
}



