using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameOver : MonoBehaviour
{
    private GameObject player;
    [SerializeReference] private string _mainMenuSceneName;
    [SerializeReference] private string _hubSceneName;
    
    private S_CountingScore _countingScore;
    private S_Rogue_Bonus _rogueBonus;
    
    public TMP_Text scoreText;
    public TMP_Text perksText;
    public TMP_Text totalText;
    
    [SerializeReference] private int _perksMultiplier = 500;
    [SerializeReference] private int _scoreDivider = 1000;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Time.timeScale = 0;
        
        player = GameObject.FindGameObjectWithTag("MainCharacter");
        _countingScore = GameObject.FindGameObjectWithTag("GUI").GetComponent<S_CountingScore>();
        _rogueBonus = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<S_Rogue_Bonus>();

        scoreText.SetText(_countingScore.currentScore.ToString());
        
        int TotalPerks = (_rogueBonus.avidityUpgradeLevel + _rogueBonus.angryKaoriUpgradeLevel + _rogueBonus.luckyShotLevel + _rogueBonus.luckyGamblerUpgradeLevel);
        perksText.SetText(TotalPerks.ToString() + " * " + _perksMultiplier.ToString() + " = " + (TotalPerks *_perksMultiplier).ToString());
        
        int Total = (_countingScore.currentScore + TotalPerks) / _scoreDivider;
        totalText.SetText( " ( " + _countingScore.currentScore.ToString() + " + " + TotalPerks.ToString() + " ) / " + _scoreDivider.ToString() + " = " + Total.ToString() );
        
        Debug.Log(Total);
        player.GetComponent<S_Resources>()._resourcesOutGame += Total;
        
        SaveRessourcesInfo();
    }

    private void SaveRessourcesInfo()
    {
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



